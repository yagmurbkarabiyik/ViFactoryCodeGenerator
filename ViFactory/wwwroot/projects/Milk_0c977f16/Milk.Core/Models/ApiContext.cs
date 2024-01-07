namespace Milk.Core.Models
{
    /// <summary>
    /// This will be added as scoped
    /// Required request-response process data such as AppUserId, AppUserBirthdate etc. will be kept here
    /// Bll and Dal can access it
    /// </summary>
    public class ApiContext
    {
        public int AppUserId { get; set; } = 0;
        public string Language { get; set; } = "tr";
    }
}
