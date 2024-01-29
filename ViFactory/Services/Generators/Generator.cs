using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using ViFactory.Models;

namespace ViFactory.Services.Generators
{
    public class Generator : IGenerator
    {
        /// <summary>
        /// This method convert codes which stay in txt files to C# code and replace some words 
        /// </summary>
        /// <param name="codeTemplate"></param>
        /// <param name="namespaceName"></param>
        /// <param name="classNameDf"></param>
        /// <param name="properties"></param>
        /// <param name="methods"></param>
        /// <param name="connectionString"></param>
        /// <param name="entityName"></param>
        /// <param name="interfaceName"></param>
        /// <param name="currentProjectName"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public string GenerateCSharpCode(string codeTemplate, string namespaceName, string classNameDf, Dictionary<string, string>? properties, Dictionary<string, string>? methods, string? connectionString, string? entityName, string? interfaceName, string? currentProjectName, string? dbContext)
        {
            var propertiesText = string.Empty;
            var methodsText = string.Empty;
            var unitText = string.Empty;

            if (properties is { Count: > 0 })
                propertiesText = string.Join("\n", properties.Select(x => $"\t\tpublic {x.Value} {x.Key}" + "{get; set;}").ToList());

            if (methods is { Count: > 0 })
                methodsText = string.Join("\n", methods.Select(x => $"\t\t{x.Value} {x.Key}" + "(T Model);").ToList());

            // replace placeholders
            string generatedCode = codeTemplate.Replace("[NamespaceName]", namespaceName)
                                               .Replace("[ClassName]", classNameDf)
                                               .Replace("[Properties]", propertiesText)
                                               .Replace("[Methods]", methodsText)
                                               .Replace("[ConnectionString]", connectionString)
                                               .Replace("[EntityName]", entityName)
                                               .Replace("[InterfaceName]", interfaceName)
                                               .Replace("[CurrentProjectName]", currentProjectName)
                                               .Replace("[DbContext]", dbContext);
            return generatedCode;
        }

        /// <summary>
        /// This method convert .txt files to .cs files
        /// </summary>
        /// <param name="generateModel"></param>
        public void GenerateClass(GeneratorModel generateModel)
        {
            string textFilePath = generateModel.InputFilePath;
            string codeTemplate = File.ReadAllText(textFilePath);

            string namespaceName = generateModel.NamespaceNameDefault;
            string className = generateModel.ClassNameDefault;

            string generatedCode = GenerateCSharpCode(codeTemplate, namespaceName, className, generateModel.Properties, generateModel.Methods, generateModel.ConnectionString, generateModel.EntityName, generateModel.InterfaceName, generateModel.CurrentProjectName, generateModel.DbContext);

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(generatedCode);

            string modelsFolderPath = Path.Combine(generateModel.OutputFilePath);

            // Create the Models folder if it doesn't exist
            if (!Directory.Exists(modelsFolderPath))
            {
                Directory.CreateDirectory(modelsFolderPath);
            }

            // Create the path for the new class file inside the Models folder
            string classFilePath = Path.Combine(modelsFolderPath, $"{className}.cs");

            File.WriteAllText(classFilePath, generatedCode);
        }
        public void GenerateEmptyFolder(GeneratorModel generatorModel)
        {
            string modelsFolderPath = Path.Combine(generatorModel.OutputFilePath);

            // Create the Models folder if it doesn't exist
            if (!Directory.Exists(modelsFolderPath))
            {
                Directory.CreateDirectory(modelsFolderPath);
            }
        }
        /// <summary>
        /// This method convert txt files to .json file
        /// </summary>
        /// <param name="generateModel"></param>
        public void GenerateJson(GeneratorModel generateModel)
        {
            string textFilePath = generateModel.InputFilePath;
            string codeTemplate = File.ReadAllText(textFilePath);

            string namespaceName = generateModel.NamespaceNameDefault;
            string className = generateModel.ClassNameDefault;

            string generatedCode = GenerateCSharpCode(codeTemplate, namespaceName, className, generateModel.Properties, generateModel.Methods, generateModel.ConnectionString, generateModel.EntityName, generateModel.InterfaceName, generateModel.CurrentProjectName, generateModel.DbContext);

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(generatedCode);

            string modelsFolderPath = Path.Combine(generateModel.OutputFilePath);

            // Create the Models folder if it doesn't exist
            if (!Directory.Exists(modelsFolderPath))
            {
                Directory.CreateDirectory(modelsFolderPath);
            }

            // Create the path for the new class file inside the Models folder
            string classFilePath = Path.Combine(modelsFolderPath, $"{className}.json");

            File.WriteAllText(classFilePath, generatedCode);
        }
    }
}