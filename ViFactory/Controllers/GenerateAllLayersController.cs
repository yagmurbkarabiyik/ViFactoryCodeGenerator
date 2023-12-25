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
		//private readonly IDomainGenerator _domainGenerator;
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
			//Identify the solutions features in detail
			SolutionGeneratorModel solutionGeneratorModel = new()
			{
				SolutionName = "ViFactorySample",
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\CreateSolution.txt",
				ProjectGuid = Guid.NewGuid().ToString("D"),
				TargetFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\"
			};
			_solutionGenerator.GenerateSolution(solutionGeneratorModel);

			//Create core layer
			ProjectGeneratorModel coreGenerator = new ProjectGeneratorModel
			{
				ProjectName = "ViFactorySample.Core",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\CreateCoreProject.txt",
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.sln"
			};
			_coreGenerator.GenerateCoreLayer(coreGenerator);

			//Create console application
			ProjectGeneratorModel consoleProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "VFConsoleApp",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\CreateConsoleApp.txt",
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.sln"
			};
			_consoleGenerator.GenerateConsoleProject(consoleProjectGenerator);

			//Create dal layer
			ProjectGeneratorModel dalProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactorySample.Dal",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\CreateDalProject.txt",
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.sln"
			};
			_dalGenerator.GenerateDalLayer(dalProjectGenerator);

			//Create dto layer
			ProjectGeneratorModel dtoProjectGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactorySample.Bll.Dtos",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dtos\\CreateDtoProject.txt",
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.sln"
			};
			_dtoGenerator.GenerateDtoLayer(dtoProjectGenerator);

			//Create bll layer
			ProjectGeneratorModel bllGenerator = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactorySample.Bll",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\CreateBllProject.txt",
				SolutionFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.sln"
			};
			_bllGenerator.GenerateBllLayer(bllGenerator);

			return Ok();
		}
	}
}
