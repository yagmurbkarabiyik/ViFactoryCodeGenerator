﻿using ViFactory.Models;
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

        public void GenerateDalLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);

			GenerateRepository(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "Common"));
			GenerateBaseMap(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "FluentApi"));
			GenerateUnitOfWork(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "Common"));
			GenerateContext(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Context"));
            GenerateAppUserRepo(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "DalRepos"));
            GenerateIAppUserRepo(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Data", "IDalRepos"));
		}

		//Constant classes
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


