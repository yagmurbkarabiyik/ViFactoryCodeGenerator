using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Domain
{
	public class DomainGenerator : IDomainGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public DomainGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}

		public void GenerateDomainLayer()
		{
			GenerateDomain();
			GenerateModels();
		}

		//Create Domain Class Library
		private void GenerateDomain()
		{
			ProjectGeneratorModel projectGeneratorModel = new ProjectGeneratorModel()
			{
				ProjectName = "ViFactorySample.Domain",
				ProjectFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Domain\\CreateDomainEntitiesProject.txt",
			};
			_projectGenerator.GenerateProject(projectGeneratorModel);	
		}
		//Generate more than one class 
		private void GenerateModels()
		{
			List<GeneratorModel> generatorModes = new()
			{
				{
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "BaseEntity",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Models\\CreateBaseEntity.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\Models\\"
					}
				},
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "Company",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Models\\CreateEntity.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\Models\\",
						Properties = new Dictionary<string, string>
						{
							{"DefaultTitle", "string" },
							{"DefaultPosterImage", "int" },
							{"Rank", "int" },
							{"CascadeRank", "int" }
						}
					},
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "Department",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Models\\CreateEntity.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\Models\\",
						Properties = new Dictionary<string, string>
						{
							{"DefaultTitle", "string" },
							{"DefaultPosterImage", "int" }
						}
					},
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "Announcement",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Models\\CreateEntity.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\Models\\",
						Properties = new Dictionary<string, string>
						{
							{"DefaultTitle", "string" },
							{"CreatDefaultPosterImageedBy", "string" },
							{"InAppRedirect", "string?" },
							{"NonAppRedirect", "string?" },
							{"Rank", "int" },
							{"CreatedBy", "int" },
							{"UpdatedBy", "int?" },
							{"StartDate", "DateTime" },
							{"Images", "List<string>?" }
						}
					},
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "AppUser",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Domain\\IdentityModels\\AppUser.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\IdentityModels\\",
						Properties = new Dictionary<string, string>
						{
							{"RefreshToken", "string?" },
							{"PasswordResetCode", "string?" },
							{"State", "DbEntityState" },
							{"CreatedDate", "DateTime" },
							{"UpdatedDate", "DateTime" },
							{"CreatedBy", "int" },
							{"UpdatedBy", "int?" },
							{"Name", "string" },
							{"Surname", "string" },
							{"DefaultPosterImage", "string?" },
							{"AppUserState", "AppUserState" },
							{"Language", "string" }
						}
					},
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "AppRole",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Domain\\IdentityModels\\AppRole.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\IdentityModels\\",
					},
					new GeneratorModel
					{
						NamespaceNameDefault = "ViFactoryNewSolution",
						ClassNameDefault = "AppUserState",
						InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Domain\\Enums\\AppUserState.txt",
						OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Domain\\Enums\\",
					}
			};

			foreach (var generatorMode in generatorModes)
			{
				_generator.GenerateClass(generatorMode);	
			}
		}
	
	} 
}