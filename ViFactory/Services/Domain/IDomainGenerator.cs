using ViFactory.Models;

namespace ViFactory.Services.Domain
{
	public interface IDomainGenerator
	{
		public void GenerateDomainLayer(ProjectGeneratorModel projectGeneratorModel);
	}
}
