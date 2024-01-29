using System.ComponentModel.DataAnnotations;
using Tea.Core.Enums;

namespace Tea.Core.Enums
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