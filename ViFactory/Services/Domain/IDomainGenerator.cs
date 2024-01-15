using ViFactory.Models;

namespace ViFactory.Services.Domain
{
	public interface IDomainGenerator
	{
		/// <summary>
		/// Create a Domain Layer
		/// </summary>
		/// <param name="projectGeneratorModel"></param>
		public void GenerateDomainLayer(ProjectGeneratorModel projectGeneratorModel);
	}
}
