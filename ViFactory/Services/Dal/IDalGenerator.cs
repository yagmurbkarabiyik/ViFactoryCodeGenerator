using ViFactory.Models;

namespace ViFactory.Services.Dal
{
	public interface IDalGenerator
	{
		/// <summary>
		/// Create a Dal Layer and classes
		/// </summary>
		/// <param name="projectGeneratorModel"></param>
		public void GenerateDalLayer(ProjectGeneratorModel projectGeneratorModel);
	}
}
