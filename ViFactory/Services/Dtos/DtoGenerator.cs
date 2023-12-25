using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Dtos
{
	public class DtoGenerator : IDtoGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public DtoGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}

		public void GenerateDtoLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);
		}

		//Generate Dto's folders and classes
		//private void GenerateDtos()
		//{
		//	GeneratorModel generateDto = new GeneratorModel()
		//	{
		//		NamespaceNameDefault = "
		//		Solution",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Dtos\\CreateDtos.txt",
		//	};

		//	//Generate more than one class and folder, and idetify class and folder name
		//	Dictionary<string, string> classFolders = new Dictionary<string, string>
		//	{
		//		{"AppUserRequestDto", "AppUserDtos"},
		//		{"AppUserResponseDto", "AppUserDtos"},
		//		{"AnnouncementRequestDto", "AnnouncementDtos"},
		//		{"AnnouncementResponesDto", "AnnouncementDtos"},
		//		{"CompanyRequestDto", "CompanyDtos"},
		//		{"CompanyResponseDto", "CompanyDtos"},
		//		{"DepartmentRequestDto", "DepartmentDtos"},
		//		{"DepartmentResponseDto", "DepartmentDtos"}
		//	};
		//	foreach (var dto in classFolders)
		//	{
		//		string className = dto.Key;
		//		string folderName = dto.Value;

		//		generateDto.OutputFilePath = $"C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Dto\\{folderName}\\";

		//		generateDto.ClassNameDefault = className;

		//		_generator.GenerateClass(generateDto);
		//	}
		//}
	}
}
