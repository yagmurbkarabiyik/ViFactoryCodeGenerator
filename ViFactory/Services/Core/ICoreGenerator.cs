using ViFactory.Models;

namespace ViFactory.Services.Core
{
    public interface ICoreGenerator
    {
        /// <summary>
        /// Create Core Layer 
        /// </summary>
        /// <param name="projectGeneratorModel"></param>
        public void GenerateCoreLayer(ProjectGeneratorModel projectGeneratorModel);
    }
}
