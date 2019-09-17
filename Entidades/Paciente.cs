using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        [Key]
        public int Id_Paciente { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
