using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Analisis
    {
        [Key]
        public int Id_Analisis { get; set; }
        public int Id_Paciente { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        
        public virtual List<AnalisisDetalle> AnalisisDetalle { get; set; }

        public Analisis()
        {
            this.AnalisisDetalle = new List<AnalisisDetalle>();
            this.Monto = 0;
            this.Balance = 0;
        }

        public void AgregarDetalle(int id_Analisis_Detalle, int id_Tipo, decimal balance, DateTime fecha)
        {
            this.AnalisisDetalle.Add(new Entidades.AnalisisDetalle(id_Analisis_Detalle, this.Id_Analisis, this.Id_Paciente, id_Tipo, balance, fecha));
        }
    }
}
