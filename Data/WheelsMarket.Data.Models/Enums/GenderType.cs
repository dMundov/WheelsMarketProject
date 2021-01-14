
namespace WheelsMarket.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum GenderType
    {
        [Display(Name = "Мъж")]
        Male,
        [Display(Name = "Жена")]
        Female,
        [Display(Name = "Друго")]
        Other

    }
}
