using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteWebMotors.Model
{
    [Table("tb_Modelo")]
    public class Modelo : BaseEntity
    {
        public int MakeId { get; set; }
        public string Name { get; set; }
    }
}
