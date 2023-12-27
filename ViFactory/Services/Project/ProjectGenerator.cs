using ViFactory.Models;

namespace ViFactory.Services.Project
{
	public class ProjectGenerator : IProjectGenerator
	{
		public void GenerateProject(ProjectGeneratorModel projectGeneratorModel)
		{
			string codeTemplate = File.ReadAllText(projectGeneratorModel.ProjectFilePath);

			//Create a project
			string projectDirectory = Path.Combine(projectGeneratorModel.OutputFolderPath,projectGeneratorModel.ProjectName);
			Directory.CreateDirectory(projectDirectory);

			File.WriteAllText(Path.Combine(projectDirectory, projectGeneratorModel.ProjectName + ".csproj"), codeTemplate);

			//Added project to existing project 
			string existSolution = File.ReadAllText(projectGeneratorModel.SolutionFilePath);

			existSolution += Environment.NewLine + $"Project(\"{Guid.NewGuid()}\") = \"{projectGeneratorModel.ProjectName}\", \"{projectGeneratorModel.ProjectName}\\{projectGeneratorModel.ProjectName}.csproj\", \"{Guid.NewGuid()}\"\nEndProject";

			codeTemplate = codeTemplate.Replace("[CurrentProjectName]", projectGeneratorModel.CurrentProjectName);

			File.WriteAllText(projectGeneratorModel.SolutionFilePath, existSolution);
			//File.WriteAllText(projectGeneratorModel.ProjectFilePath, codeTemplate);
			File.ReadAllText(projectGeneratorModel.SolutionFilePath);
		}
	}
}