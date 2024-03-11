using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Data.Entities
{
    public class Nutfree
    {
        [Key]
        public int NutfreeID { get; set; }
        public string Nutfreename { get; set; }
    }
}
