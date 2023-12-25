using ViFactory.Models;

namespace ViFactory.Services.Project
{
    public class ProjectGenerator : IProjectGenerator
    {
        public void GenerateProject(ProjectGeneratorModel projectGeneratorModel)
        {
			string codeTemplate = File.ReadAllText(projectGeneratorModel.ProjectFilePath);

			//Create a project
			string projectDirectory = Path.Combine($"C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\{projectGeneratorModel.ProjectName}");
			Directory.CreateDirectory(projectDirectory);

			File.WriteAllText(Path.Combine(projectDirectory, projectGeneratorModel.ProjectName + ".csproj"), codeTemplate);

			//Added project to existing project 
			string existSolution = File.ReadAllText(projectGeneratorModel.SolutionFilePath);

			existSolution += Environment.NewLine + $"Project(\"{Guid.NewGuid()}\") = \"{projectGeneratorModel.ProjectName}\", \"{projectGeneratorModel.ProjectName}\\{projectGeneratorModel.ProjectName}.csproj\", \"{Guid.NewGuid()}\"\nEndProject";


			File.WriteAllText(projectGeneratorModel.SolutionFilePath, existSolution);

			File.ReadAllText(projectGeneratorModel.SolutionFilePath);
		}
    }
}