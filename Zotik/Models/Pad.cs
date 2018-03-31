using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zotik.Enums;

namespace Zotik.Models
{
    [Table("Pads")]
    public class Pad
    {
        [Required, Key]
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Вид")]
        public Types Type { get; set; }

        [DisplayName("Материал")]
        public Materials Material { get; set; }
    }
}
