using Microsoft.AspNetCore.Mvc;
using ViFactory.Models;
using ViFactory.Services.Bll;
using ViFactory.Services.Console;
using ViFactory.Services.Core;
using ViFactory.Services.Dal;
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
		private readonly ISolutionGenerator _solutionGenerator;
		private readonly IConsoleGenerator _consoleGenerator;
		public GenerateAllLayersController(IBllGenerator bllGenerator, IDtoGenerator dtoGenerator, IDalGenerator dalGenerator, ICoreGenerator coreGenerator, ISolutionGenerator solutionGenerator, IConsoleGenerator consoleGenerator)
		{
			_bllGenerator = bllGenerator;
			_dtoGenerator = dtoGenerator;
			_dalGenerator = dalGenerator;
			_coreGenerator = coreGenerator;
			_solutionGenerator = solutionGenerator;
			_consoleGenerator = consoleGenerator;
		}
		public IActionResult GenerateAll()
		{
			string projectName = "Ybk";
			string outputFolderPath = "C:\\Users\\ygmr4\\Desktop\\" + projectName;

			//Identify the solutions features in detail
			SolutionGeneratorModel solutionGeneratorModel = new()
			{
				SolutionName = projectName,
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\CreateSolution.txt",
				ProjectGuid = Guid.NewGuid().ToString("D"),
				TargetFilePath = outputFolderPath
			};
			_solutionGenerator.GenerateSolution(solutionGeneratorModel);
			
			#region Create Core Layer
			ProjectGeneratorModel coreGenerator = new ProjectGeneratorModel
			{
				ProjectName = $"{solutionGeneratorModel.SolutionName}.Core",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\CreateCoreProject.txt",
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
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\CreateConsoleApp.txt",
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
			    ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\CreateDalProject.txt",
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
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dtos\\CreateDtoProject.txt",
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
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\CreateBllProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, projectName + ".sln"),
				OutputFolderPath = outputFolderPath,
				CurrentProjectName = projectName
			};

			_bllGenerator.GenerateBllLayer(bllGenerator);
			#endregion

			return Ok();
		}
	}
}

