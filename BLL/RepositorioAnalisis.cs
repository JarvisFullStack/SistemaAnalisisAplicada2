using DAL;
using Entidades;
using System;
using System.Linq;

namespace BLL
{
    public class RepositorioAnalisis : RepositorioBase<Analisis>
    {

        public override bool Guardar(Analisis entity)
        {
            bool ok = false;
            try
            {                
                foreach(var item in entity.AnalisisDetalle)
                {
                    _context.Entry(item).State = System.Data.Entity.EntityState.Added;    
                }

                decimal monto = entity.AnalisisDetalle.Sum(x=>x.Monto);
                entity.Monto = entity.Balance = monto;
                if (_context.Set<Analisis>().Add(entity) != null)
                {
                    _context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ok;
        }

        public override Analisis Buscar(int id)
        {
            Analisis entity;
            try
            {
                entity = _context.Set<Analisis>().Find(id);
                if (entity != null)
                {
                    entity.AnalisisDetalle.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public override bool Modificar(Analisis entity)
        {
            bool ok = false;
            try
            {
                //Buscando el analisis anterior
                Contexto contextoaAnalisis = new Contexto();
                Analisis analisisAnterior = contextoaAnalisis.Set<Analisis>().Find(entity.Id_Analisis);
                //Estableciendo estado a las listas eliminadas
                foreach (AnalisisDetalle itemAnterior in analisisAnterior.AnalisisDetalle)
                {
                    if (!entity.AnalisisDetalle.Contains(itemAnterior))
                    {
                        itemAnterior.Analisis = null;                        
                        itemAnterior.TipoAnalisis = null;
                        contextoaAnalisis.Entry(itemAnterior).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                //Estableciendo las listas agregadas
                foreach (var item in entity.AnalisisDetalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id_Analisis_Detalle > 0 ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
                    contextoaAnalisis.Entry<AnalisisDetalle>(item).State = estado;
                }
                contextoaAnalisis.SaveChanges();
                entity.Monto = entity.AnalisisDetalle.Sum(x => x.Monto);
                entity.Balance = entity.AnalisisDetalle.Sum(x => x.Balance);
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (_context.SaveChanges() > 0)
                {
                    ok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ok;
        }
    }
}
