using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteWebMotors.Model
{
    [Table("tb_versao")]
    public class Versao : BaseEntity
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
    }
}
