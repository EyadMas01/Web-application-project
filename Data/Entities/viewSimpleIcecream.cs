using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Data.Entities
{
    public class viewSimpleIcecream
    {
        [Key]
        public int IcecreamID { get; set; }
        public string Icecreamname { get; set; }
        public string Descriptions { get; set; }
        public string Imagepath { get; set; }
        public int IcecreamSizeID { get; set; }
        public int PrimaryFlavoursID { get; set; }
        public int SpecialsID { get; set; }
        public int NutfreeID { get; set; }
        public string IcecreamSizename { get; set; }
        public decimal price { get; set; }
        public string PrimaryFlavoursname { get; set; }
        public string Nutfreename { get; set; }
        public string SpecialDay { get; set; }

    }
}
