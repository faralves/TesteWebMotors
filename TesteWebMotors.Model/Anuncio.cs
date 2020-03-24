using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteWebMotors.Model
{
    [Table("tb_AnuncioWebmotors")]
    public class Anuncio : BaseEntity
    {

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public string Versao { get; set; } = "";

        public int Ano { get; set; } = 0;

        public int Quilometragem { get; set; } = 0;

        public string Observacao { get; set; } = "";
    }
}
