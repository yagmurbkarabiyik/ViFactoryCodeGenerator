using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Dal
{
	public class DalGenerator : IDalGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		private readonly IWebHostEnvironment _webHostEnvironment;
        public DalGenerator(IGenerator generator, IProjectGenerator projectGenerator, IWebHostEnvironment webHostEnvironment)
        {
            _generator = generator;
            _projectGenerator = projectGenerator;
            _webHostEnvironment = webHostEnvironment;
        }
		/// <summary>
		/// Create Dal Layer and constant classes
		/// </summary>
		/// <param name="projectGeneratorModel"></param>
        public void GenerateDalLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);

			GenerateRepository(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "Common"));
            GenerateAppUserRepo(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "DalRepos"));
            GenerateIAppUserRepo(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "IDalRepos"));
			GenerateUnitOfWork(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "Common"));
			GenerateBaseMap(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "FluentApi"));
			GenerateContext(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Context"));
		}
		/// <summary>
		/// Create a general Repository class in the Data//Common folder
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="outputFilePath"></param>
		private void GenerateRepository(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepository = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Dal.Data.Common",
				ClassNameDefault = "Repository",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Dal\\Data\\Common\\Repository.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateRepository);
		}
		/// <summary>
		/// Create a Base Map class for fluent api in the FluentApi folder
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="outputFilePath"></param>
		private void GenerateBaseMap(string projectName, string outputFilePath)
		{
			GeneratorModel generateBaseMap = new()
			{
				NamespaceNameDefault = projectName + ".Dal.FluentApi",
				ClassNameDefault = "BaseMap",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Dal\\FluentApi\\BaseMap.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName,
				DbContext = projectName +"DbContext"
			};
			_generator.GenerateClass(generateBaseMap);
		}
		/// <summary>
		/// Create a UnitOfWork class in the Data//Common folder
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="outputFilePath"></param>
		private void GenerateUnitOfWork(string projectName, string outputFilePath)
		{
			GeneratorModel generatorUnitOfWork = new()
			{
				NamespaceNameDefault = projectName + ".Dal.Data.Common",
				ClassNameDefault = "UnitOfWork",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Dal\\Data\\Common\\UnitOfWork.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName,
				DbContext = projectName+"DbContext"
			};
			_generator.GenerateClass(generatorUnitOfWork);
		}
		/// <summary>
		/// Create a Context class according to project name
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="outputFilePath"></param>
		private void GenerateContext(string projectName, string outputFilePath)
		{
			GeneratorModel generatorContext = new()
			{
				NamespaceNameDefault = projectName + ".Dal.Context",
				ClassNameDefault = projectName + "DbContext",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Dal\\Data\\Context\\Context.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generatorContext);
		}
		/// <summary>
		/// Create a AppUserRepository class in the DalRepository folder
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="outputFilePath"></param>
		private void GenerateAppUserRepo(string projectName, string outputFilePath) 
		{
			GeneratorModel generateAppUserRepo = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Dal.Data.DalRepos",
				ClassNameDefault = "AppUserRepository",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Dal\\Data\\DalRepos\\AppUserRepository.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName,
				DbContext = $"{projectName}DbContext"
			};
			_generator.GenerateClass(generateAppUserRepo);
		}
		/// <summary>
		/// Create a IAppUserRepository class in the IDalRepository folder
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="outputFilePath"></param>
		private void GenerateIAppUserRepo(string projectName, string outputFilePath)
		{
			GeneratorModel generateIAppUserRepo = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Dal.Data.IDalRepos",
				ClassNameDefault = "IAppUserRepository",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Dal\\Data\\DalRepos\\IAppUserRepository.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName,
				DbContext = $"{projectName}DbContext"
			};
			_generator.GenerateClass(generateIAppUserRepo);
		}
	}
}