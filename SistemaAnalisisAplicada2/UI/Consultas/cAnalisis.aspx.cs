using BLL;
using Entidades;
using SistemaAnalisisAplicada2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaAnalisisAplicada2.UI.Consultas
{
    public partial class cAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscarButton_Click((object)this.BuscarButton, new EventArgs());
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Analisis, bool>> filtro = x => true;
            RepositorioAnalisis repositorio = new RepositorioAnalisis();
            int id;
            int idPaciente;
            if (!string.IsNullOrEmpty(FiltroTextBox.Text))
            {


                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0://ID
                        id = Soporte.ToInt(FiltroTextBox.Text);
                        filtro = c => c.Id_Analisis == id;
                        break;
                    case 1:// codigo Cliente
                        idPaciente = Soporte.ToInt(FiltroTextBox.Text);
                        filtro = c => c.Id_Paciente == idPaciente;
                        break;
                }
            }
            List<Analisis> lista = repositorio.GetList(filtro);
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }
    }
}