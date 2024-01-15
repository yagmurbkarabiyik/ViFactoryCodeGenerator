using ViFactory.Models;
using ViFactory.Services.Generators;

namespace ViFactory.Services.Solution
{
	/// <summary>
	/// Create new solution and save .sln file for the project
	/// </summary>
	public class SolutionGenertor : ISolutionGenerator
	{
		private readonly IGenerator _generator;
		public SolutionGenertor(IGenerator generator)
		{
			_generator = generator;
		}
		public void GenerateSolution(SolutionGeneratorModel solutionGeneratorModel)
		{
			string solutionFilePath = solutionGeneratorModel.SolutionFilePath;
			string solutionName = solutionGeneratorModel.SolutionName;

			//Generate solution
			string solutionContent = GenerateSolutionCode(solutionFilePath);

			//Generate and save .sln file 
			string solutionCreatedFile = Path.Combine(solutionGeneratorModel.TargetFilePath,solutionName+".sln");

			if (!Directory.Exists(solutionGeneratorModel.TargetFilePath))
			{
				Directory.CreateDirectory(solutionGeneratorModel.TargetFilePath);
			}
			
			File.WriteAllText(solutionCreatedFile, solutionContent);
		}

		//Generate a code for solution
		private string GenerateSolutionCode(string solutionFilePath)
		{
			string solutionContent = File.ReadAllText(solutionFilePath);

			return solutionContent;
		}

	}
}
