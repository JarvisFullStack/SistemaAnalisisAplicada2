using BLL;
using Entidades;
using SistemaAnalisisAplicada2.Utilidades;
using System;
using System.Web.UI;

namespace SistemaAnalisisAplicada2.UI.Registros
{
    public partial class rPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //si llego in id
                int id = Soporte.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Paciente> repositorio = new RepositorioBase<Paciente>();
                    var paciente = repositorio.Buscar(id);

                    if (paciente == null)
                    {
                        MostrarMensaje("Registro no encontrado", "error");
                    }
                    else
                    {
                        LlenaCampos(paciente);
                    }
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            ErrorLabel.Text = string.Empty;
        }

        private void Limpiar()
        {
            this.IdTextBox.Text = string.Empty;
            this.NombreTextBox.Text = string.Empty;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Paciente> repositorio = new RepositorioBase<Paciente>();
            Paciente paciente = new Paciente();
            paciente = LlenaClase();
            bool paso = false;
            if (paciente.Id_Paciente <= 0) //Creando
            {
                paciente.Fecha_Creacion = DateTime.Now;
                paso = repositorio.Guardar(paciente);
                if (paso)
                {
                    Limpiar();
                }
            }
            else
            {
                paso = repositorio.Modificar(paciente);
            }
            if (paso)
            {
                MostrarMensaje("success", "Transaccion Existosa");
            }
            else
            {
                MostrarMensaje("error", "Transaccion Fallida");
            }

        }

        private Paciente LlenaClase()
        {
            Paciente paciente = new Paciente();
            paciente.Id_Paciente = Soporte.ToInt(IdTextBox.Text);
            paciente.Nombre = NombreTextBox.Text;
            return paciente;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(this.IdTextBox.Text) || string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MostrarMensaje("error", "Transacion Fallida");
                return;
            }
            id = Soporte.ToInt(IdTextBox.Text);
            RepositorioBase<Paciente> repositorio = new RepositorioBase<Paciente>();
            if (repositorio.Buscar(id) == null)
            {
                MostrarMensaje("error", "Transacion Fallida");
                return;
            }
            bool eliminado = repositorio.Eliminar(id);
            if (eliminado)
            {
                MostrarMensaje("success", "Transacion Exitosa");
                Limpiar();
                return;
            }

        }

        void MostrarMensaje(string tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == "success")
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }

        private void LlenaCampos(Paciente paciente)
        {
            this.IdTextBox.Text = paciente.Id_Paciente.ToString();
            NombreTextBox.Text = paciente.Nombre;
        }
    }


}
