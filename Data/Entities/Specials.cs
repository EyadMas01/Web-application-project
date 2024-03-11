using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Data.Entities
{
    public class Specials
    {
        [Key]
        public int SpecialsID { get; set; }
        public string SpecialDay { get; set; }
    }
}
