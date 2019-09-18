using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Paciente
    {
        [Key]
        public int Id_Paciente { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        public Paciente()
        {
            Fecha_Creacion = DateTime.Now;
        }

    }
}
