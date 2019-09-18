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
                ViewState["Analisis"] = new Analisis();
                //si llego in id                
                int idAnalisis = Soporte.ToInt(Request.QueryString["idAnalisis"]);
                if (idAnalisis > 0)
                {
                    BLL.RepositorioAnalisis repositorio = new BLL.RepositorioAnalisis();
                    var analisis = repositorio.Buscar(idAnalisis);
                    ViewState["Analisis"] = new Analisis();
                    if (analisis == null)
                    {
                        MostrarMensaje("error", "Registro no encontrado");
                    }
                    else
                    {
                        MostrarMensaje("success", "Busqueda Completa");
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
            DetalleGridView.DataSource = ((Analisis)ViewState["Analisis"]).AnalisisDetalle;
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
            ViewState["Analisis"] = analisis;
            LlenaGrid();

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Analisis LlenaClase()
        {
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];
            analisis.Id_Analisis = Soporte.ToInt(IdTextBox.Text);
            analisis.Id_Paciente = Soporte.ToInt(PacienteDropDownList.SelectedValue);
            //analisis.AnalisisDetalle = (List<AnalisisDetalle>)DetalleGridView.DataSource;
            return analisis;
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioAnalisis repositorio = new RepositorioAnalisis();
            Analisis analisis = LlenaClase();
            if (Soporte.ToInt(IdTextBox.Text) == 0)
                paso = repositorio.Guardar(analisis);

            else
                paso = repositorio.Modificar(analisis);

            if (paso)
            {
                MostrarMensaje("success", "Transaccion Exitosa");
                Limpiar();
            } else
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
            ViewState["Analisis"] = new Analisis();
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
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];                 
            int idAnalisis = Soporte.ToInt(IdTextBox.Text);
            int idPaciente = Soporte.ToInt(PacienteDropDownList.SelectedValue);
            int idTipo = Soporte.ToInt(TipoAnalisisDropDownList.SelectedValue);
            TipoAnalisis tipoAnalisis = new RepositorioBase<TipoAnalisis>().Buscar(idTipo);
            AnalisisDetalle detalle = new AnalisisDetalle(0, idAnalisis, idPaciente, idTipo, DateTime.Now, tipoAnalisis.Precio, tipoAnalisis.Precio);
            detalle.TipoAnalisis = tipoAnalisis;
            analisis.AnalisisDetalle.Add(detalle);
            ViewState["Analisis"] = analisis;            
            LlenaGrid();
        }
    }


}