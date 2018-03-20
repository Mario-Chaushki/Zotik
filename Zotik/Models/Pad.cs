﻿using System.ComponentModel.DataAnnotations;
using Zotik.Enums;

namespace Zotik.Models
{
    public class Pad
    {
        [Required]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public Types Type { get; set; }
        
        public Materials Material { get; set; }
    }
}
