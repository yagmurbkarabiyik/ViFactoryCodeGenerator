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
			//GenerateRepository();
			//GenerateDbContext();
			//GenerateUnitOfWork();
			//GenerateDalRepos();
			//GenerateIDalRepos();
		}

		//Generate classes
		//private void GenerateRepository()
		//{
		//	GeneratorModel generateCommonClass = new GeneratorModel()
		//	{
		//		NamespaceNameDefault = "ViFactoryNew.Dal",
		//		ClassNameDefault = "Repository",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\Data\\Common\\Repository.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Dal\\Data\\Common\\",
		//	};
		//	_generator.GenerateClass(generateCommonClass);	
		//}
		//Generate DbContext
		//private void GenerateDbContext()
		//{
		//	GeneratorModel generateDbContext = new GeneratorModel()
		//	{
		//		NamespaceNameDefault = "ViFactoryNew.Dal",
		//		ClassNameDefault = "ViFactoryDbContext",
		//		ConnectionString = "(\"server=YAGMUR;database=ViFactoryDb;integrated security=true;TrustServerCertificate=true\")",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\ViFactoryDbContext.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Dal\\Context\\",
		//	};

		//	_generator.GenerateClass(generateDbContext);
		//}
		//private void GenerateUnitOfWork()
		//{
		//	GeneratorModel generateUnitOfWork = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "UnitOfWork",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\Data\\Common\\UnitOfWork.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\\\Desktop\\ViFactoryNew\\ViFactoryNew.Dal\\Data\\Common"
		//	};
		//	_generator.GenerateClass(generateUnitOfWork);
		//}
		//private void GenerateDalRepos()
		//{
		//	string[] entityNames = { "Announcement", "Company", "Department" }; 

		//	foreach (string entityName in entityNames)
		//	{
		//		GeneratorModel generateDalRepos = new GeneratorModel()
		//		{
		//			NamespaceNameDefault = "ViFactoryNewSolution",
		//			ClassNameDefault = entityName + "Repository",
		//			EntityName = entityName,
		//			InterfaceName = "I" + entityName + "Repository",
		//			InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\Data\\DalRepos\\DalRepos.txt",
		//			OutputFilePath = "C:\\Users\\ygmr4\\\\Desktop\\ViFactoryNew\\ViFactoryNew.Dal\\Data\\DalRepos"
		//		};
		//		_generator.GenerateClass(generateDalRepos);
		//	}
		//}
		//private void GenerateIDalRepos()
		//{
		//	string[] entityNames = { "Announcement", "Company", "Department" }; 

		//	foreach (string entityName in entityNames)
		//	{
		//		GeneratorModel generateIDalRepos = new GeneratorModel()
		//		{
		//			NamespaceNameDefault = "ViFactoryNewSolution",
		//			ClassNameDefault = "I" + entityName + "Repository",
		//			EntityName = entityName,
		//			InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dal\\Data\\DalRepos\\IDalRepos.txt",
		//			OutputFilePath = "C:\\Users\\ygmr4\\\\Desktop\\ViFactoryNew\\ViFactoryNew.Dal\\Data\\IDalRepos"
		//		};
		//		_generator.GenerateClass(generateIDalRepos);
		//	}
		//}
	}
}


