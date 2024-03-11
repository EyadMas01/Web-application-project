using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Data.Entities
{
    public class PrimaryFlavours
    {
        [Key]
        public int PrimaryFlavoursID { get; set; }
        public string PrimaryFlavoursname { get; set; }
    }
}
