using BLL;
using Entidades;
using SistemaAnalisisAplicada2.Utilidades;
using System;
using System.Linq.Expressions;

namespace SistemaAnalisisAplicada2.UI.Consultas
{
    public partial class cTiposAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscarButton_Click((object)this.BuscarButton, new EventArgs());
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<TipoAnalisis, bool>> filtro = x => true;
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            int id;
            if (!string.IsNullOrEmpty(FiltroTextBox.Text))
            {


                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0://ID
                        id = Soporte.ToInt(FiltroTextBox.Text);
                        filtro = c => c.Id_Tipo_Analisis == id;
                        break;
                    case 1:// nombre
                        filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                        break;
                    case 2:// precio
                        filtro = c => c.Precio == Soporte.ToDecimal(FiltroTextBox.Text);
                        break;
                }
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }
    }
}