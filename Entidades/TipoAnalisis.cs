using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class TipoAnalisis
    {
        [Key]
        public int Id_Tipo_Analisis { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        public TipoAnalisis()
        {
            this.Precio = 0;
            this.Fecha_Creacion = DateTime.Now;
        }
    }
}
