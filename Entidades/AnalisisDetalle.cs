using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AnalisisDetalle
    {
        [Key]
        public int Id_Analisis_Detalle { get; set; }
        public int Id_Analisis { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Balance { get; set; }
        [ForeignKey("Id_Analisis")]
        public virtual Analisis Analisis { get; set; }

        public AnalisisDetalle(int id_Analisis_Detalle, int id_Analisis, int id_Paciente, int id_Tipo, decimal balance, DateTime fecha)
        {
            Id_Analisis_Detalle = id_Analisis_Detalle;
            Id_Analisis = id_Analisis;
            Id_Paciente = id_Paciente;
            Id_Tipo = id_Tipo;
            Fecha = fecha;
            this.Balance = balance;
        }

        public AnalisisDetalle()
        {
            this.Fecha = DateTime.Now;
            this.Balance = 0;
        }
    }
}
