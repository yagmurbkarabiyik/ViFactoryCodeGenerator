using System.ComponentModel.DataAnnotations;
using ExtensionsDeneme.Core.Enums;

namespace ExtensionsDeneme.Core.Enums
{
    public enum DbEntityState
    {
        [Display(Name = "Aktif")]
        Active = 1,
        [Display(Name = "Pasif")]
        Passive = 2,
        [Display(Name = "Silinmiş")]
        Deleted = 3
    }
}