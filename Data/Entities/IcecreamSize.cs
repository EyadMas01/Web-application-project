using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Data.Entities
{
    public class IcecreamSize
    {
        [Key]
        public int IcecreamSizeID { get; set; }
        public string IcecreamSizename { get; set; }
        public decimal price { get; set; }
    }
}
