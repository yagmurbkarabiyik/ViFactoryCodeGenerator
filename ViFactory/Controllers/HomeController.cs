using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;
using ViFactory.Models;
using ViFactory.Services.Api;
using ViFactory.Services.Bll;
using ViFactory.Services.Console;
using ViFactory.Services.Core;
using ViFactory.Services.Dal;
using ViFactory.Services.Domain;
using ViFactory.Services.Dtos;
using ViFactory.Services.Solution;

namespace ViFactory.Controllers
{
	/// <summary>
	/// Create all layers that we need to for the wholw project 
	/// </summary>
	public class HomeController : Controller
	{
		private readonly ICoreGenerator _coreGenerator;
		private readonly IDalGenerator _dalGenerator;
		private readonly IDtoGenerator _dtoGenerator;
		private readonly IBllGenerator _bllGenerator;
		private readonly IDomainGenerator _domainGenerator;
		private readonly ISolutionGenerator _solutionGenerator;
		private readonly IConsoleGenerator _consoleGenerator;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IApiGenerator _apiGenerator;
        public HomeController(IBllGenerator bllGenerator, IDtoGenerator dtoGenerator, IDalGenerator dalGenerator, ICoreGenerator coreGenerator, ISolutionGenerator solutionGenerator, IConsoleGenerator consoleGenerator, IWebHostEnvironment webHostEnvironment, IDomainGenerator domainGenerator, IApiGenerator apiGenerator)
        {
            _bllGenerator = bllGenerator;
            _dtoGenerator = dtoGenerator;
            _dalGenerator = dalGenerator;
            _coreGenerator = coreGenerator;
            _solutionGenerator = solutionGenerator;
            _consoleGenerator = consoleGenerator;
            _webHostEnvironment = webHostEnvironment;
            _domainGenerator = domainGenerator;
            _apiGenerator = apiGenerator;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return RedirectToAction("ProjectCreate");
		}

		[HttpGet]
		public IActionResult ProjectCreate()
        {
            return View();
        }

        [HttpPost]
		public IActionResult ProjectCreate(ProjectCreateDto dto)
		{
			if (!ModelState.IsValid)
				return View(dto);

			var path = ProjectCreateProcess(dto.ProjectName);

            ZipFile.CreateFromDirectory(path, path + ".zip");

            return PhysicalFile(path + ".zip", "application/zip", $"{dto.ProjectName}.zip");
        }

		private string ProjectCreateProcess(string projectName)
		{
			var projectNameUnique = $"{projectName}_{Guid.NewGuid().ToString().Split("-")[0]}";

            string outputFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "projects", projectNameUnique);

			//Identify the solutions features in detail
			SolutionGeneratorModel solutionGeneratorModel = new()
			{
				SolutionName = projectName,
				SolutionFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "CreateSolution.txt"),
				ProjectGuid = Guid.NewGuid().ToString("D"),
				TargetFilePath = outputFolderPath
			};
			_solutionGenerator.GenerateSolution(solutionGeneratorModel);

			#region Create Core Layer
			ProjectGeneratorModel coreGenerator = new ProjectGeneratorModel
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Core",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Core", "CreateCoreProject.txt"),
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
			_coreGenerator.GenerateCoreLayer(coreGenerator);
			#endregion

			#region Create Console Application
			ProjectGeneratorModel consoleProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactory",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "ConsoleApp", "CreateConsoleApp.txt"),
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
			_consoleGenerator.GenerateConsoleProject(consoleProjectGenerator);
			#endregion

			#region Create Dal Layer
			ProjectGeneratorModel dalProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Dal",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Dal", "CreateDalProject.txt"),
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
			_dalGenerator.GenerateDalLayer(dalProjectGenerator);
			#endregion

			#region Create Bll Layer
			ProjectGeneratorModel bllGenerator = new ProjectGeneratorModel()
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Bll",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Bll", "CreateBllProject.txt"),
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
         
            _bllGenerator.GenerateBllLayer(bllGenerator);
            #endregion

            #region Generate Api Project
			ProjectGeneratorModel generateApiProject = new ProjectGeneratorModel()
			{
				ProjectName = $"{projectName}.Api",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api", "CreateApiProject.txt"),
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
			_apiGenerator.GenerateApiProject(generateApiProject);

            #endregion

            #region Create Domain Layer
            ProjectGeneratorModel domainGenerator = new ProjectGeneratorModel()
            {
                ProjectName = $"{solutionGeneratorModel.SolutionName}.Domain.Entities",
                ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Domain\\CreateDomainEntitiesProject.txt",
                SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
                OutputFolderPath = outputFolderPath,
                CurrentProjectName = projectName
            };
            _domainGenerator.GenerateDomainLayer(domainGenerator);
            #endregion

            return outputFolderPath;
		}
    }
}