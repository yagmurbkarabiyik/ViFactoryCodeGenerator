using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Dal
{
	public class DalGenerator : IDalGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public DalGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}

		public void GenerateDalLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);

			GenerateRepository(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "Common"));
			GenerateAzurBlobStorage(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "Common"));
			GenerateBaseMap(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "FluentApi"));
		}

		//Constant classes
		private  void GenerateRepository(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepository = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Dal.Data.Common",
				ClassNameDefault = "Repository",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\Data\\Common\\Repository.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateRepository);
		}
		private void GenerateAzurBlobStorage(string projectName, string outputFilePath)
		{
			GeneratorModel azurBlobStorage = new()
			{
				NamespaceNameDefault = projectName + ".Dal.Data.Common",
				ClassNameDefault = "AzureBlobStorageService",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\Data\\Common\\AzureBlobStorageService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(azurBlobStorage);
		}
		private void GenerateBaseMap(string projectName, string outputFilePath)
		{
			GeneratorModel generateBaseMap = new()
			{
				NamespaceNameDefault = projectName + ".Dal.FluentApi",
				ClassNameDefault = "BaseMap",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\FluentApi\\BaseMap.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName,
				DbContext = projectName +"DbContext"
			};
			_generator.GenerateClass(generateBaseMap);
		}
	}
}


