using Microsoft.AspNetCore.Identity;
using aws.Core.Enums;


namespace aws.Domain.IdentityModels
{
    public class AppUser : IdentityUser<int>
    {
        		public string? RefreshToken{get; set;}
		public string? PasswordResetCode{get; set;}
		public DbEntityState State{get; set;}
		public DateTime CreatedDate{get; set;}
		public DateTime UpdatedDate{get; set;}
		public int CreatedBy{get; set;}
		public int? UpdatedBy{get; set;}
		public string Name{get; set;}
		public string Surname{get; set;}
		public string? DefaultPosterImage{get; set;}
		public AppUserState AppUserState{get; set;}
		public string Language{get; set;}
    }
}


