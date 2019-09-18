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
    public class PacienteTest
    {
        [TestMethod]
        public void Guardar()
        {
            Paciente paciente = new Paciente();
            paciente.Nombre = "Felipe";
            Assert.IsTrue(new RepositorioBase<Paciente>().Guardar(paciente));
        }

        [TestMethod]
        public void Buscar()
        {
            Assert.IsTrue(new RepositorioBase<Paciente>().Buscar(1) != null);
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Paciente> repositorio = new RepositorioBase<Paciente>();
            Paciente paciente = repositorio.Buscar(1);
            paciente.Nombre = "Luis Felipe";
            Assert.IsTrue(repositorio.Modificar(paciente));
        }


    }
}
