using Microsoft.AspNetCore.Identity;


namespace Coffee.Domain.IdentityModels
{
    public class AppRole : IdentityRole<int>
    {
        public string? RefreshToken { get; set; }
        public string? PasswordResetCode { get; set; }
        public DbEntityState State { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? DefaultPosterImage { get; set; }
        public AppUserState AppUserState { get; set; }
        public string Language { get; set; } = null!;
    }
}


