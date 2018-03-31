using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zotik.Enums
{
    public enum Materials
    {
        [Display(Name = "Памук")]
        Cotton = 0,
        [Display(Name = "Коприна")]
        Silk = 1
    }
}
