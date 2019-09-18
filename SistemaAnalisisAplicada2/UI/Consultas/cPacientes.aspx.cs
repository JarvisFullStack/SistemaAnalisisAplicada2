using BLL;
using Entidades;
using SistemaAnalisisAplicada2.Utilidades;
using System;
using System.Linq.Expressions;

namespace SistemaAnalisisAplicada2.UI.Consultas
{
    public partial class cPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscarButton_Click((object)this.BuscarButton, new EventArgs());
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Paciente, bool>> filtro = x => true;
            RepositorioBase<Paciente> repositorio = new RepositorioBase<Paciente>();
            int id;
            if (!string.IsNullOrEmpty(FiltroTextBox.Text))
            {


                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0://ID
                        id = Soporte.ToInt(FiltroTextBox.Text);
                        filtro = c => c.Id_Paciente == id;
                        break;
                    case 1:// nombre
                        filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                        break;
                }
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }
    }
}