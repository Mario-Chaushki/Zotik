using System.ComponentModel.DataAnnotations;

namespace Zotik.Enums
{
    public enum Types
    {
        [Display(Name = "Нощни")]
        Night = 0,
        [Display(Name = "Супер нощни")]
        SuperNight = 1,
        [Display(Name = "Дневни")]
        Day = 2,
    }
}
