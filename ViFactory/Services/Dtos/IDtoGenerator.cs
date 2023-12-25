using ViFactory.Models;
using ViFactory.Services.Generators;

namespace ViFactory.Services.Dtos
{
	public interface IDtoGenerator
	{
		public void GenerateDtoLayer(ProjectGeneratorModel projectGeneratorModel);
	}
}
