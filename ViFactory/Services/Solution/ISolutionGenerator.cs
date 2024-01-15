using ViFactory.Models;

namespace ViFactory.Services.Solution
{
	public interface ISolutionGenerator
	{
		/// <summary>
		/// Create a new solution
		/// </summary>
		/// <param name="solutionGeneratorModel"></param>
		public void GenerateSolution(SolutionGeneratorModel solutionGeneratorModel);
	}
}
