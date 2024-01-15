using ViFactory.Models;

namespace ViFactory.Services.Bll
{
	public interface IBllGenerator
	{
		/// <summary>
		/// Create a Bll Layer and constant classes
		/// </summary>
		/// <param name="projectGeneratorModel"></param>
		public void GenerateBllLayer(ProjectGeneratorModel projectGeneratorModel);
	}
}
