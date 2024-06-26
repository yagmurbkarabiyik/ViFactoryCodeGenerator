using System.Reflection;
using System.Xml.Linq;
using ViFactory;

class Program
{
	 static void Main()
	 {
		string projectName = FileUtils.GetSolutionFileName().Substring(0, FileUtils.GetSolutionFileName().Length-4);
		string outputFolderPath = FileUtils.GetSolutionDir();

		// Find class name from domain.entities layer | used as general
		var entities = GetTypesFromAssembly($"{projectName}.Domain.Entities", $"{projectName}.Domain.Entities.Models");

		string dalFolderPath = Path.Combine(outputFolderPath, projectName + ".Dal");
		string csprojDalFilePath = Path.Combine(outputFolderPath, dalFolderPath, projectName + ".Dal.csproj");

		string bllFolderPath = Path.Combine(outputFolderPath, projectName + ".Bll");
		string csprojBllFilePath = Path.Combine(outputFolderPath, bllFolderPath, projectName + ".Bll.csproj");

        string apiControllerFolderPath = Path.Combine(outputFolderPath, $"{projectName}.Api");
        string csprojApiFilePath = Path.Combine(outputFolderPath, bllFolderPath, projectName + "ViFactory.API.csproj");

        GenerateDal(csprojDalFilePath, dalFolderPath, entities, projectName);
		GenerateBll(csprojBllFilePath, bllFolderPath, entities, projectName);

		GenerateApiController(csprojApiFilePath, apiControllerFolderPath, entities, projectName);

     }

	#region Assembly Load
	static List<Type> GetTypesFromAssembly(string assemblyName, string typeNameStart)
	{
		return Assembly.Load(assemblyName)
			.GetTypes()
			.Where(x => x.FullName.StartsWith(typeNameStart))
			.ToList();
	}
	#endregion

	#region Generate Bll

	static void GenerateBll(string csprojFilePath, string rootFolderPath, IEnumerable<Type> entities, string currentProjectName)
	{
		XDocument csprojDoc = XDocument.Load(csprojFilePath);
		XElement itemGroup = csprojDoc.Root.Elements("ItemGroup").FirstOrDefault();
		if (itemGroup == null)
		{
			itemGroup = new XElement("ItemGroup");
			csprojDoc.Root.Add(itemGroup);
		}

		string serviceFolderPath = Path.Combine(rootFolderPath, "Services", "Concrete");
		string iServiceFolderPath = Path.Combine(rootFolderPath, "Services", "Abstract");
		string modelsFolderPath = Path.Combine(rootFolderPath, "Models");
		string enumsFolderPath = Path.Combine(rootFolderPath, "Enums");
		string commonServiceFolderPath = Path.Combine(rootFolderPath, "Services", "Common");
		string uploadLocalServicePath = Path.Combine(rootFolderPath, "Services", "Common");

		EnsureDirectoryExists(serviceFolderPath);
		EnsureDirectoryExists(iServiceFolderPath);
		EnsureDirectoryExists(modelsFolderPath);
		EnsureDirectoryExists(enumsFolderPath);
		EnsureDirectoryExists(commonServiceFolderPath);
		EnsureDirectoryExists(uploadLocalServicePath);

		foreach (var entity in entities)
		{
			string serviceClass = Path.Combine(serviceFolderPath, $"{entity.Name}Service.cs");
			string iServiceClass = Path.Combine(iServiceFolderPath, $"I{entity.Name}Service.cs");

			if (entity.Name != "BaseEntity")
			{
				EnsureFileExists(serviceClass, File.ReadAllText("./Templates/Service.txt")
					.Replace("[CurrentProjectName]", currentProjectName)
					.Replace("[EntityName]", entity.Name));

				EnsureFileExists(iServiceClass, File.ReadAllText("./Templates/IService.txt")
					.Replace("[CurrentProjectName]", currentProjectName)
					.Replace("[EntityName]", entity.Name));
			}
		}
		csprojDoc.Save(csprojFilePath);

		GenerateDtos(csprojFilePath, Path.Combine(rootFolderPath, "Dtos"), entities, currentProjectName);
    }

    static void GenerateDtos(string csprojFilePath, string rootFolderPath, IEnumerable<Type> entities, string currentProjectName)
    {
		if (!Directory.Exists(rootFolderPath)) Directory.CreateDirectory(rootFolderPath);

        XDocument csprojDoc = XDocument.Load(csprojFilePath);

        XElement itemGroup = csprojDoc.Root.Elements("ItemGroup").FirstOrDefault();
        if (itemGroup == null)
        {
            itemGroup = new XElement("ItemGroup");
            csprojDoc.Root.Add(itemGroup);
        }

        foreach (var entity in entities)
        {
            string folderPath = Path.Combine(rootFolderPath, entity.Name + "Dtos");

            EnsureDirectoryExists(folderPath);

            string createDtoClass = Path.Combine(folderPath, $"{entity.Name}CreateDto.cs");
            string readDtoClass = Path.Combine(folderPath, $"{entity.Name}ReadDto.cs");
            string updateDtoClass = Path.Combine(folderPath, $"{entity.Name}UpdateDto.cs");
            string getDtoClass = Path.Combine(folderPath, $"{entity.Name}GetDto.cs");
            string getListDtoClass = Path.Combine(folderPath, $"{entity.Name}GetListDto.cs");

            if (entity.Name != "BaseEntity")
            {
                EnsureFileExists(createDtoClass, File.ReadAllText("./Templates/CreateDto.txt")
                    .Replace("[CurrentProjectName]", currentProjectName)
                    .Replace("[EntityName]", entity.Name + "CreateDto"));

                EnsureFileExists(readDtoClass, File.ReadAllText("./Templates/CreateDto.txt")
                    .Replace("[CurrentProjectName]", currentProjectName)
                    .Replace("[EntityName]", entity.Name + "ReadDto"));

                EnsureFileExists(updateDtoClass, File.ReadAllText("./Templates/CreateDto.txt")
                    .Replace("[CurrentProjectName]", currentProjectName)
                    .Replace("[EntityName]", entity.Name + "UpdateDto"));

                EnsureFileExists(getDtoClass, File.ReadAllText("./Templates/CreateDto.txt")
                    .Replace("[CurrentProjectName]", currentProjectName)
                    .Replace("[EntityName]", entity.Name + "GetDto"));

                EnsureFileExists(getListDtoClass, File.ReadAllText("./Templates/CreateDto.txt")
                    .Replace("[CurrentProjectName]", currentProjectName)
                    .Replace("[EntityName]", entity.Name + "GetListDto"));
            }
        }
        csprojDoc.Save(csprojFilePath);
    }
    #endregion

    #region Generate Dal
    static void GenerateDal(string csprojFilePath, string rootFolderPath, IEnumerable<Type> entities, string currentProjectName)
	{
		string connectionString = "User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=visdb;";

		XDocument csprojDoc = XDocument.Load(csprojFilePath);
		XElement itemGroup = csprojDoc.Root.Elements("ItemGroup").FirstOrDefault();
		if (itemGroup == null)
		{
			itemGroup = new XElement("ItemGroup");
			csprojDoc.Root.Add(itemGroup);
		}

		string folderDalReposPath = Path.Combine(rootFolderPath, "Data", "DalRepos");
		string folderIDalReposPath = Path.Combine(rootFolderPath, "Data", "IDalRepos");
		string commonFolderPath = Path.Combine(rootFolderPath, "Data", "Common");
		string contextFolderPath = Path.Combine(rootFolderPath, "Context");
		string fluentApiFolderPath = Path.Combine(rootFolderPath, "FluentApi");
		
		EnsureDirectoryExists(folderDalReposPath);
		EnsureDirectoryExists(folderIDalReposPath);
		EnsureDirectoryExists(commonFolderPath);
		EnsureDirectoryExists(contextFolderPath);
		EnsureDirectoryExists(fluentApiFolderPath);

		foreach (var entity in entities)
		{
			// Create empty C# class files for dalRepos and IDalRepos
			string dalReposClass = Path.Combine(folderDalReposPath, $"{entity.Name}Repository.cs");
			string iDalReposClass = Path.Combine(folderIDalReposPath, $"I{entity.Name}Repository.cs");
			string repositoryClass = Path.Combine(commonFolderPath, "Repository.cs");
			string fluentApiClass = Path.Combine(fluentApiFolderPath, $"{entity.Name}Map.cs");
			string baseMapClass = Path.Combine(fluentApiFolderPath, "BaseMap.cs");
			string unitOfWorkClass = Path.Combine(commonFolderPath, "UnitOfWork.cs");

			if (entity.Name != "BaseEntity")
			{
				EnsureFileExists(iDalReposClass, File.ReadAllText("./Templates/IDalRepository.txt")
					.Replace("[CurrentProjectName]", currentProjectName)
					.Replace("[EntityName]", entity.Name));

				EnsureFileExists(dalReposClass, File.ReadAllText("./Templates/DalRepository.txt")
					.Replace("[CurrentProjectName]", currentProjectName)
					.Replace("[EntityName]", entity.Name)
					.Replace("[DbContext]", currentProjectName));
				
				EnsureFileExists(fluentApiClass, File.ReadAllText("./Templates/FluentApiMap.txt")
					 .Replace("[TableName]", GetTableName(entity.Name))
					 .Replace("[CurrentProjectName]", currentProjectName)
					 .Replace("[EntityName]", entity.Name));

				EnsureFileExists(unitOfWorkClass, File.ReadAllText("./Templates/UnitOfWork.txt")
					 .Replace("[CurrentProjectName]", currentProjectName)
					 .Replace("[DbContext]", $"{currentProjectName}DbContext"));
			}
		}

		//Regenerate dbContext class
		string contextClass = Path.Combine(contextFolderPath, $"{currentProjectName}DbContext.cs");

		var currentContextText = File.ReadAllText(contextClass);

		var customConstructorText = currentContextText.Substring(currentContextText.IndexOf("#region CustomConstructor"), currentContextText.IndexOf("#endregion CustomConstructor") - currentContextText.IndexOf("#region CustomConstructor") + "#endregion CustomConstructor".Length+1);

        var customOnModelCreatingText = currentContextText.Substring(currentContextText.IndexOf("#region CustomOnModelCreating"), currentContextText.IndexOf("#endregion CustomOnModelCreating") - currentContextText.IndexOf("#region CustomOnModelCreating") + "#endregion CustomOnModelCreating".Length + 1);

        var customText = currentContextText.Substring(currentContextText.IndexOf("#region CustomCode"), currentContextText.IndexOf("#endregion CustomCode") - currentContextText.IndexOf("#region CustomCode") + "#endregion CustomCode".Length + 1);

		var customUsingText = currentContextText.Substring(currentContextText.IndexOf("#region CustomUsing"), currentContextText.IndexOf("#endregion CustomUsing") - currentContextText.IndexOf("#region CustomUsing") + "#endregion CustomUsing".Length + 1);

        File.WriteAllText(contextClass, File.ReadAllText("./Templates/Context.txt")
					.Replace("[CurrentProjectName]", currentProjectName)
					.Replace("[Properties]", string.Join("\n\t\t", entities
						   .Where(x => x.Name != "BaseEntity")
						   .Select(x => $"public DbSet<{x.Name}> {GetTableName(x.Name)} {{ get; set; }}").ToList()))
				   .Replace("[FluentMapApi]", string.Join("\n\t\t", entities
						   .Where(x => x.Name != "BaseEntity")
						   .Select(x => $"builder.ApplyConfiguration(new {x.Name}Map());").ToList()))
					.Replace("[ConnectionString]", connectionString)
					.Replace("[CustomConstructor]", customConstructorText)
					.Replace("[CustomOnModelCreating]", customOnModelCreatingText)
					.Replace("[CustomCode]", customText)
					.Replace("[CustomUsing]", customUsingText));


        csprojDoc.Save(csprojFilePath);
	}
    #endregion

	#region Create Controller
    static void GenerateApiController(string csprojFilePath, string rootFolderPath, IEnumerable<Type> entities, string currentProjectName)
    {
        string apiControllerFolderPath = Path.Combine(rootFolderPath, "Controllers");
        EnsureDirectoryExists(apiControllerFolderPath);

        foreach (var entity in entities)
        {
            string pluralEntityName = ToPlural(entity.Name);
            string singularEntityName = ToSingular(entity.Name);

            string controllerClass = Path.Combine(apiControllerFolderPath, $"{pluralEntityName}Controller.cs");

            if (entity.Name != "BaseEntity")
            {
				EnsureFileExists(controllerClass, File.ReadAllText("./Templates/ApiController.txt")
					.Replace("[CurrentProjectName]", currentProjectName)
					.Replace("[InterfaceName]", entity.Name)
					.Replace("[ControllerClassName]", $"{char.ToUpper(pluralEntityName[0])}{pluralEntityName.Substring(1)}")
					.Replace("[InterfaceName]", $"{char.ToLower(pluralEntityName[0])}{pluralEntityName.Substring(1)}")
					.Replace("[LowerCaseServiceName]", $"{char.ToLower(singularEntityName[0])}{singularEntityName.Substring(1)}"));
            }
        }
    }
    #endregion

	#region Helper Methods
    static void EnsureFileExists(string filePath, string content)
	{
		if (!File.Exists(filePath))
		{
			File.WriteAllText(filePath, content);
		}
	}
	static void EnsureDirectoryExists(string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
		}
	}
	static string GetTableName(string entityName)
	{
		string tableName = entityName;

		if (tableName.EndsWith("y", StringComparison.OrdinalIgnoreCase))
		{
			tableName = tableName.Substring(0, tableName.Length - 1) + "ies";
		}
	    else if (tableName.EndsWith("s", StringComparison.OrdinalIgnoreCase))
        {
            return tableName + "es";
        }
		else
		{
			tableName += "s";
		}

		return tableName;
	}
	static string ToPlural(string singular)
    {
        if (string.IsNullOrEmpty(singular))
            return singular;

        if (singular.EndsWith("y", StringComparison.OrdinalIgnoreCase))
        {
            return singular.Substring(0, singular.Length - 1) + "ies";
        }
        else if (singular.EndsWith("s", StringComparison.OrdinalIgnoreCase))
        {
            return singular + "es";
        }
        else
        {
            return singular + "s";
        }
    }
    static string ToSingular(string plural)
    {
        if (string.IsNullOrEmpty(plural))
            return plural;

        if (plural.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
        {
            return plural.Substring(0, plural.Length - 3) + "y";
        }
        else if (plural.EndsWith("es", StringComparison.OrdinalIgnoreCase))
        {
            return plural.Substring(0, plural.Length - 2);
        }
        else if (plural.EndsWith("s", StringComparison.OrdinalIgnoreCase))
        {
            return plural.Substring(0, plural.Length - 1);
        }
        else
        {
            return plural;
        }
    }
    #endregion
}