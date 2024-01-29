using Microsoft.AspNetCore.Mvc;
using ViFactory.Models;
using ViFactory.Services.Bll;
using ViFactory.Services.Console;
using ViFactory.Services.Core;
using ViFactory.Services.Dal;
using ViFactory.Services.Domain;
using ViFactory.Services.Dtos;
using ViFactory.Services.Solution;

namespace ViFactory.Controllers
{
    public class GenerateAllLayersController : Controller
	{
		private readonly ICoreGenerator _coreGenerator;
		private readonly IDalGenerator _dalGenerator;
		private readonly IDtoGenerator _dtoGenerator;
		private readonly IBllGenerator _bllGenerator;
		private readonly IDomainGenerator _domainGenerator;
		private readonly ISolutionGenerator _solutionGenerator;
		private readonly IConsoleGenerator _consoleGenerator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GenerateAllLayersController(IBllGenerator bllGenerator, IDtoGenerator dtoGenerator, IDalGenerator dalGenerator, ICoreGenerator coreGenerator, ISolutionGenerator solutionGenerator, IConsoleGenerator consoleGenerator, IWebHostEnvironment webHostEnvironment, IDomainGenerator domainGenerator)
        {
            _bllGenerator = bllGenerator;
            _dtoGenerator = dtoGenerator;
            _dalGenerator = dalGenerator;
            _coreGenerator = coreGenerator;
            _solutionGenerator = solutionGenerator;
            _consoleGenerator = consoleGenerator;
            _webHostEnvironment = webHostEnvironment;
            _domainGenerator = domainGenerator;
        }
        public IActionResult GenerateAll()
		{
			string projectName = "Ybk";
			string outputFolderPath = "C:\\Users\\ygmr4\\Desktop\\" + projectName;

			//Identify the solutions features in detail
			SolutionGeneratorModel solutionGeneratorModel = new()
			{
				SolutionName = projectName,
				SolutionFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\CreateSolution.txt",
				ProjectGuid = Guid.NewGuid().ToString("D"),
				TargetFilePath = outputFolderPath
			};
			_solutionGenerator.GenerateSolution(solutionGeneratorModel);
			
			#region Create Core Layer
			ProjectGeneratorModel coreGenerator = new ProjectGeneratorModel
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Core",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\CreateCoreProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName= projectName
			};
			
			_coreGenerator.GenerateCoreLayer(coreGenerator);
			#endregion

			#region Create Console Application
			ProjectGeneratorModel consoleProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactory",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\CreateConsoleApp.txt",
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
			    ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Dal\\CreateDalProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
			_dalGenerator.GenerateDalLayer(dalProjectGenerator);
			#endregion

			#region Create Dto Layer
			ProjectGeneratorModel dtoProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Bll.Dtos",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Dtos\\CreateDtoProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName

			};
			
			_dtoGenerator.GenerateDtoLayer(dtoProjectGenerator);

			#endregion

			#region Create Bll Layer
			ProjectGeneratorModel bllGenerator = new ProjectGeneratorModel()
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Bll",
				ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\CreateBllProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};
			_bllGenerator.GenerateBllLayer(bllGenerator);
            #endregion

            #region Create Domain Layer
            ProjectGeneratorModel domainGenerator = new ProjectGeneratorModel()
            {
                ProjectName = $"{solutionGeneratorModel.SolutionName}.Domain",
                ProjectFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Domain\\CreateDomainEntitiesProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
            };
			_domainGenerator.GenerateDomainLayer(domainGenerator);
            #endregion

            return Ok();
		}
    }
}