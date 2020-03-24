using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteWebMotors.Model
{
    [Table("tb_Marca")]
    public class Marca : BaseEntity
    {
        public string Name { get; set; }
    }
}
