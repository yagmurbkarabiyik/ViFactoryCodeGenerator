using ViFactory.Models;

namespace ViFactory.Services.Api
{
    public interface IApiGenerator
    {
        /// <summary>
        /// Create a Api Project and constant classes
        /// </summary>
        /// <param name="projectGeneratorModel"></param>
        public void GenerateApiProject(ProjectGeneratorModel projectGeneratorModel);

    }
}
