using BLL;
using Entidades;
using SistemaAnalisisAplicada2.Utilidades;
using System;

namespace SistemaAnalisisAplicada2.UI.Registros
{
    public partial class rTipoAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //si llego in id
                int id = Soporte.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
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
            this.PrecioTextBox.Text = string.Empty;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis tipoAnalisis = new TipoAnalisis();
            tipoAnalisis = LlenaClase();
            bool paso = false;
            if (tipoAnalisis.Id_Tipo_Analisis <= 0) //Creando
            {
                tipoAnalisis.Fecha_Creacion = DateTime.Now;
                paso = repositorio.Guardar(tipoAnalisis);
                if (paso)
                {
                    Limpiar();
                }
            }
            else
            {
                paso = repositorio.Modificar(tipoAnalisis);
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

        private TipoAnalisis LlenaClase()
        {
            TipoAnalisis tipoAnalisis = new TipoAnalisis();
            tipoAnalisis.Id_Tipo_Analisis = Soporte.ToInt(IdTextBox.Text);
            tipoAnalisis.Nombre = NombreTextBox.Text;
            tipoAnalisis.Precio = Soporte.ToDecimal(PrecioTextBox.Text);
            return tipoAnalisis;
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
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
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

        private void LlenaCampos(TipoAnalisis tipoAnalisis)
        {
            this.IdTextBox.Text = tipoAnalisis.Id_Tipo_Analisis.ToString();
            NombreTextBox.Text = tipoAnalisis.Nombre;
            PrecioTextBox.Text = tipoAnalisis.Precio.ToString();
        }
    }
}