using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAnalisisAplicada2.Test
{
    [TestClass]
    public class TipoAnalisisTest
    {
        [TestMethod]
        public void Guardar()
        {
            TipoAnalisis tipoAnalisis = new TipoAnalisis();
            tipoAnalisis.Nombre = "Hemograma";
            tipoAnalisis.Precio = 200;
            Assert.IsTrue(new RepositorioBase<TipoAnalisis>().Guardar(tipoAnalisis));
        }


        [TestMethod]
        public void Buscar()
        {
            Assert.IsTrue(new RepositorioBase<TipoAnalisis>().Buscar(1) != null);
        }

        [TestMethod]
        public void Modificar()
        {
            TipoAnalisis tipoAnalisis = new RepositorioBase<TipoAnalisis>().Buscar(1);
            tipoAnalisis.Precio = 300;
            Assert.IsTrue(new RepositorioBase<TipoAnalisis>().Modificar(tipoAnalisis));
        }


    }
}
