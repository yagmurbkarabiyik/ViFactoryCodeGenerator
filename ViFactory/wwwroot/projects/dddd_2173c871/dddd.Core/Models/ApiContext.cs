namespace dddd.Core.Models
{
    /// <summary>
    /// This will be added as scoped
    /// Required request-response process data such as AppUserId, AppUserBirthdate etc. will be kept here
    /// Bll and Dal can access it
    /// </summary>
    public class ApiContext
    {
        public int? AppUserId { get; set; }
        public string? AppUserFullName { get; set; }
        public string? AppUserName { get; set; }
        public string? Email { get; set; }
        public string? ClientType { get; set; }
        public string? Language { get; set; }
        public string? SignInRemoteIp { get; set; }
        public string? CurrentRemoteIp { get; set; }
    }
}