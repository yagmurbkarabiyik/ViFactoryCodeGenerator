using ViFactory.Models;

namespace ViFactory.Services.Dal
{
	public interface IDalGenerator
	{
		public void GenerateDalLayer(ProjectGeneratorModel projectGeneratorModel);
	}
}
