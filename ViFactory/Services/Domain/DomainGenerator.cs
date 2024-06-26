﻿using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Domain
{
	public class DomainGenerator : IDomainGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DomainGenerator(IGenerator generator, IProjectGenerator projectGenerator, IWebHostEnvironment webHostEnvironment)
        {
            _generator = generator;
            _projectGenerator = projectGenerator;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Create a Domain Layer and constant classes
        /// </summary>
        /// <param name="projectGeneratorModel"></param>
        public void GenerateDomainLayer(ProjectGeneratorModel projectGeneratorModel)
		{
            _projectGenerator.GenerateProject(projectGeneratorModel);

           GenerateBaseEntity(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
           GenerateAppUser(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "IdentityModels"));
           GenerateAppRole(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "IdentityModels"));
           GenerateAppUserState(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "IdentityModels"));
        }

        /// <summary>
        /// This method create a BaseEntity class in the Models folder
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        private void GenerateBaseEntity(string projectName, string outputFilePath)
        {
            GeneratorModel generateBaseEntity = new GeneratorModel()
            {
                NamespaceNameDefault = projectName + ".Domain.Entities.Models",
                ClassNameDefault = "BaseEntity",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Models\\CreateBaseEntity.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };

            _generator.GenerateClass(generateBaseEntity);
        }
        /// <summary>
        /// This method create a constant AppUser class in the IdentityModels folder
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        private void GenerateAppUser(string projectName, string outputFilePath) 
        {
            GeneratorModel generateAppUser = new GeneratorModel()
            {
                NamespaceNameDefault = projectName + ".Domain.IdentityModels",
                ClassNameDefault = "AppUser",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Domain\\IdentityModels\\AppUser.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName,
                Properties = new Dictionary<string, string>
                        {
                            {"RefreshToken", "string?" },
                            {"PasswordResetCode", "string?" },
                            {"State", "DbEntityState" },
                            {"CreatedDate", "DateTime" },
                            {"UpdatedDate", "DateTime" },
                            {"CreatedBy", "int" },
                            {"UpdatedBy", "int?" },
                            {"Name", "string" },
                            {"Surname", "string" },
                            {"DefaultPosterImage", "string?" },
                            {"AppUserState", "AppUserState" }
                        }
            };
            _generator.GenerateClass(generateAppUser);
        }
        /// <summary>
        /// This method create a AppRole class in the IdentityModels folder
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        private void GenerateAppRole(string projectName, string outputFilePath)
        {
            GeneratorModel generateAppRole = new GeneratorModel()
            {
                NamespaceNameDefault = projectName + ".Domain.IdentityModels",
                ClassNameDefault = "AppRole",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Domain\\IdentityModels\\AppRole.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName,

            };
            _generator.GenerateClass(generateAppRole);
        }
        /// <summary>
        /// This method create a AppUserState class in the IdentityModels folder
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        private void GenerateAppUserState(string projectName, string outputFilePath)
        {
            GeneratorModel generatorModel = new GeneratorModel()
            {
                NamespaceNameDefault = projectName + ".Domain.IdentityModels",
                ClassNameDefault = "AppUserState",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Domain\\Enums\\AppUserState.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName,
            };
            _generator.GenerateClass(generatorModel);
        }
    } 
}