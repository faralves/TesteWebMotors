using System.ComponentModel.DataAnnotations.Schema;

namespace TesteWebMotors.Model
{
    [Table("tb_veiculo")]
    public class Veiculo : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public string Image { get; set; }
        public int KM { get; set; }
        public decimal Price { get; set; }
        public int YearModel { get; set; }
        public int YearFab { get; set; }
        public string Color { get; set; }
    }
}
