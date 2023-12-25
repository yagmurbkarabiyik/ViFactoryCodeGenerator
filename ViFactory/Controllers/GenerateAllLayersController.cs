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

		public IActionResult GenerateAll(string outputFolderPath, string solutionName)
		{
			solutionName = "Yamur";
			outputFolderPath = "C:\\Users\\ygmr4\\Desktop\\" + solutionName;

			//Identify the solutions features in detail
			SolutionGeneratorModel solutionGeneratorModel = new()
			{
				SolutionName = solutionName,
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\CreateSolution.txt",
				ProjectGuid = Guid.NewGuid().ToString("D"),
				TargetFilePath = outputFolderPath
			};
			_solutionGenerator.GenerateSolution(solutionGeneratorModel);

			#region Create Core Layer
			ProjectGeneratorModel coreGenerator = new ProjectGeneratorModel
			{
				ProjectName = solutionName+".Core",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\CreateCoreProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, solutionName+".sln"),
				OutputFolderPath = outputFolderPath
			};
			
			_coreGenerator.GenerateCoreLayer(coreGenerator);
			#endregion

			#region Create Console Application
			ProjectGeneratorModel consoleProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactory",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\CreateConsoleApp.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, solutionName + ".sln"),
				OutputFolderPath = outputFolderPath
			};
			_consoleGenerator.GenerateConsoleProject(consoleProjectGenerator);
			#endregion

			#region Create Dal Layer
			ProjectGeneratorModel dalProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = solutionName+".Dal",
			    ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\CreateDalProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, solutionName + ".sln"),
				OutputFolderPath = outputFolderPath
			};
			// Replace operation
			string dalContent = System.IO.File.ReadAllText(dalProjectGenerator.ProjectFilePath);
			dalContent = dalContent.Replace("[CurrentProjectName]", $"{solutionName}");
			System.IO.File.WriteAllText(dalProjectGenerator.ProjectFilePath, dalContent);

			_dalGenerator.GenerateDalLayer(dalProjectGenerator);
			#endregion

			#region Create Dto Layer
			ProjectGeneratorModel dtoProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = solutionName+".Bll.Dtos",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dtos\\CreateDtoProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, solutionName + ".sln"),
				OutputFolderPath = outputFolderPath
			};

			_dtoGenerator.GenerateDtoLayer(dtoProjectGenerator);

			#endregion

			#region Create Bll Layer
			ProjectGeneratorModel bllGenerator = new ProjectGeneratorModel()
			{
				ProjectName = solutionName+".Bll",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\CreateBllProject.txt",
				SolutionFilePath = Path.Combine(outputFolderPath, solutionName + ".sln"),
				OutputFolderPath = outputFolderPath,
			};

			_bllGenerator.GenerateBllLayer(bllGenerator);
			#endregion

			return Ok();
		}
	}
}
