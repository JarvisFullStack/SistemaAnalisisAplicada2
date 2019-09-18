using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Serializable]
    public class AnalisisDetalle
    {
        [Key]
        public int Id_Analisis_Detalle { get; set; }
        public int Id_Analisis { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        [ForeignKey("Id_Analisis")]
        public virtual Analisis Analisis { get; set; }
        [ForeignKey("Id_Tipo")]
        public virtual TipoAnalisis TipoAnalisis { get; set; }

        public AnalisisDetalle(int id_Analisis_Detalle, int id_Analisis, int id_Paciente, int id_Tipo, DateTime fecha, decimal monto, decimal balance)
        {
            Id_Analisis_Detalle = id_Analisis_Detalle;
            Id_Analisis = id_Analisis;
            Id_Paciente = id_Paciente;
            Id_Tipo = id_Tipo;
            Fecha = fecha;
            Monto = monto;
            Balance = balance;
        }

        public AnalisisDetalle()
        {
            this.Fecha = DateTime.Now;
            this.Balance = 0;
            this.Monto = 0;
        }

        public override bool Equals(object obj)
        {
            return this.Id_Analisis == ((AnalisisDetalle)obj).Id_Analisis;
        }
    }
}
