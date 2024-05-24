using CeuEscuro.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.user
{
    public partial class ConsultaFilm : System.Web.UI.Page
    {
        FilmeBLL objBLL = new FilmeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGV2();
        }
        //popular gv2
        public void PopularGV2()
        {
            gv2.DataSource = objBLL.GetFilms_Film();
            gv2.DataBind();
        }
    }
}