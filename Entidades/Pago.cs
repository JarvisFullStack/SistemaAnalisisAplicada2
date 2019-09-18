using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pago
    {
        [Key]
        public int Id_Pago { get; set; }
        public int Id_Analisis { get; set; }

        public virtual List<PagoDetalle> PagoDetalle { get; set; }

        public Pago()
        {
            this.PagoDetalle = new List<PagoDetalle>();
        }

        public void AgregarDetalle(int Id_Analisis_Detalle, decimal Monto)
        {
            this.PagoDetalle.Add(new Entidades.PagoDetalle(this.Id_Pago, this.Id_Analisis, Id_Analisis_Detalle, Monto, DateTime.Now));            
        }
    }
}
