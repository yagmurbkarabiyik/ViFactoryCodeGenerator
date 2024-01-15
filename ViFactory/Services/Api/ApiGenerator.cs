using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Api
{
    public class ApiGenerator : IApiGenerator
    {
        private readonly IProjectGenerator _projectGenerator;
        private readonly IGenerator _generator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApiGenerator(IProjectGenerator projectGenerator, IGenerator generator, IWebHostEnvironment webHostEnvironment)
        {
            _projectGenerator = projectGenerator;
            _generator = generator;
            _webHostEnvironment = webHostEnvironment;
        }
        /// <summary>
        /// Create Api Project and constant classes
        /// </summary>
        /// <param name="projectGeneratorModel"></param>
        public void GenerateApiProject(ProjectGeneratorModel projectGeneratorModel)
        {
            _projectGenerator.GenerateProject(projectGeneratorModel);
            GenerateProgramCs(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName));
            GenerateDbcontext(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Extensions"));
            GenerateFluentValidator(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Extensions"));
            GenerateService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Extensions"));
            GenerateCustomException(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Middlewares"));
            GenerateAppSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName));
            GenerateApiBehaviour(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Config"));
            GenerateAppUsersController(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Controllers"));
        }
        /// <summary>
        /// Create a Program.cs for Api Project
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        public void GenerateProgramCs(string projectName, string outputFilePath)
        {
            GeneratorModel generateProgramCs = new GeneratorModel
            {
                ClassNameDefault = "Program",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Api\\ProgramCs.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateClass(generateProgramCs);
        }
        /// <summary>
        /// Create a AppSettings for Api Project
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        public void GenerateAppSettings(string projectName, string outputFilePath)
        {
            GeneratorModel generateAppSettings = new GeneratorModel
            {
                ClassNameDefault = "appsettings",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template" + "\\Api\\AppSettings.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateJson(generateAppSettings);
        }
        /// <summary>
        /// Api/ExtensionsFolder Constant Classes Created
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="outputFilePath"></param>
        /// 
        #region Create Extensions Folder DiDbContext, FluentValidation, and DiService
        public void GenerateDbcontext(string projectName, string outputFilePath)
        {
            GeneratorModel generateDbContext = new GeneratorModel()
            {
                ClassNameDefault = "DiDbContext",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api" + "\\Extensions\\DiDbContext.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName,
                DbContext = $"{projectName}DbContext"
            };
            _generator.GenerateClass(generateDbContext);
        }
        public void GenerateFluentValidator(string projectName, string outputFilePath)
        {
            GeneratorModel generateDiFluentValidator = new GeneratorModel()
            {
                ClassNameDefault = "DiFluentValidator",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api" + "\\Extensions\\DiFluentValidator.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName,
                DbContext = $"{projectName}DbContext"
            };
            _generator.GenerateClass(generateDiFluentValidator);
        }
        public void GenerateService(string projectName, string outputFilePath)
        {
            GeneratorModel generateService = new GeneratorModel()
            {
                ClassNameDefault = "DiService",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api" + "\\Extensions\\DiServices.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName,
                DbContext = $"{projectName}DbContext"
            };
            _generator.GenerateClass(generateService);
        }
        #endregion

        #region Create Middlewares
        public void GenerateCustomException(string projectName, string outputFilePath)
        {
            GeneratorModel generateCustomException = new GeneratorModel()
            {
                ClassNameDefault = "CustomExceptionMiddleware",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api" + "\\Middlewares\\CustomExceptionMiddleware.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateClass(generateCustomException);
        }
        #endregion

        #region Create ApiBehaviour Config 
        public void GenerateApiBehaviour(string projectName, string outputFilePath)
        {
            GeneratorModel generateApiBehaviour = new GeneratorModel()
            {
                ClassNameDefault = "ApiBehaviourConfig",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api" + "\\Config\\ApiBehaviourConfig.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateClass(generateApiBehaviour);
        }
        #endregion

        #region Create AppUsersControllers 
        public void GenerateAppUsersController(string projectName, string outputFilePath)
        {
            GeneratorModel generateAppUsersController = new GeneratorModel()
            {
                ClassNameDefault = "AppUsersController",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template", "Api" + "\\Controller\\AppUsersController.txt"),
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateClass(generateAppUsersController);
        }
        #endregion
    }
};