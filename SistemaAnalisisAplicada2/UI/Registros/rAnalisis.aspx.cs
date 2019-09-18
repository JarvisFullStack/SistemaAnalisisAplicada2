using BLL;
using Entidades;
using SistemaAnalisisAplicada2.Utilidades;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace SistemaAnalisisAplicada2.UI.Registros
{
    public partial class rAnalisis : System.Web.UI.Page
    {
        public List<AnalisisDetalle> listaAnalisisDetalle = new List<AnalisisDetalle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //si llego in id
                int idPaciente = Soporte.ToInt(Request.QueryString["idPaciente"]);
                int idAnalisis = Soporte.ToInt(Request.QueryString["idAnalisis"]);
                if (idAnalisis > 0 && idPaciente > 0)
                {
                    BLL.RepositorioAnalisis repositorio = new BLL.RepositorioAnalisis();
                    var analisis = repositorio.Buscar(idAnalisis);

                    if (analisis == null)
                    {
                        MostrarMensaje("error", "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampos(analisis);
                    }
                }
                else
                {
                    LlenaComboBoxPacientes();
                    LlenaComboBoxTiposAnalisis();
                }



            }
        }

        private void LlenaComboBoxTiposAnalisis()
        {
            List<TipoAnalisis> lista = new RepositorioBase<TipoAnalisis>().GetList(x => true);
            TipoAnalisisDropDownList.DataSource = null;
            TipoAnalisisDropDownList.DataSource = lista;
            TipoAnalisisDropDownList.DataTextField = "Nombre";
            TipoAnalisisDropDownList.DataValueField = "Id_Tipo_Analisis";
            TipoAnalisisDropDownList.DataBind();
        }

        private void LlenaGrid()
        {
            DetalleGridView.DataSource = null;
            DetalleGridView.DataSource = this.listaAnalisisDetalle;
            DetalleGridView.DataBind();
        }

        private void LlenaComboBoxPacientes()
        {
            List<Paciente> lista = new RepositorioBase<Paciente>().GetList(x => true);
            PacienteDropDownList.DataSource = null;
            PacienteDropDownList.DataSource = lista;
            PacienteDropDownList.DataTextField = "Nombre";
            PacienteDropDownList.DataValueField = "Id_Paciente";
            PacienteDropDownList.DataBind();
        }

        private void LlenaCampos(Analisis analisis)
        {
            LlenaComboBoxPacientes();
            LlenaComboBoxTiposAnalisis();
            this.IdTextBox.Text = analisis.Id_Analisis.ToString();
            List<Paciente> listaPaciente = (List<Paciente>)PacienteDropDownList.DataSource;
            PacienteDropDownList.SelectedIndex = listaPaciente.IndexOf(listaPaciente.Find(x => x.Id_Paciente == analisis.Id_Paciente));
            PacienteDropDownList.Enabled = false;
            TipoAnalisisDropDownList.SelectedIndex = 0;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Analisis LlenaClase()
        {
            Analisis analisis = new Analisis();
            analisis.Id_Analisis = Soporte.ToInt(IdTextBox.Text);
            analisis.Id_Paciente = Soporte.ToInt(PacienteDropDownList.SelectedValue);
            analisis.AnalisisDetalle = this.listaAnalisisDetalle;
            return analisis;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioAnalisis repositorio = new BLL.RepositorioAnalisis();
            Analisis analisis = new Analisis();
            analisis = LlenaClase();
            bool paso = false;
            if (analisis.Id_Analisis <= 0) //Creando
            {
                paso = repositorio.Guardar(analisis);
                if (paso)
                {
                    Limpiar();
                }
            }
            else
            {
                paso = repositorio.Modificar(analisis);
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

        private void Limpiar()
        {
            this.IdTextBox.Text = string.Empty;
            LlenaComboBoxPacientes();
            LlenaComboBoxTiposAnalisis();
            this.listaAnalisisDetalle = new List<AnalisisDetalle>();
            this.ErrorLabel.Text = string.Empty;
            this.PacienteDropDownList.Enabled = true;
            this.LlenaGrid();
        }

        void MostrarMensaje(string tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == "success")
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

        }



        protected void DetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BotonAgregarDetalle_Click(object sender, EventArgs e)
        {

        }
    }


}