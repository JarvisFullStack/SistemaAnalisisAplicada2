using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PagoDetalle
    {
        [Key]
        public int Id_Pago_Detalle { get; set; }
        public int Id_Pago { get; set; }
        public int Id_Analisis { get; set; }       
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Id_Pago")]
        public virtual Pago Pago { get; set; }

        public PagoDetalle(int id_Pago ,int id_Analisis , decimal monto, DateTime fecha)
        {
            this.Id_Pago = id_Pago;
            this.Id_Analisis = id_Analisis;            
            Monto = monto;
            Fecha = fecha;
        }

        public PagoDetalle()
        {
            this.Monto = 0;
            this.Fecha = DateTime.Now;
        }
    }
}
