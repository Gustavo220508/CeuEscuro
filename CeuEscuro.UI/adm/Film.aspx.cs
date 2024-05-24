using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.UI.utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.adm
{
    public partial class Film : System.Web.UI.Page
    {
        FilmeDTO objDTO = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();




        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                PopularGV2();
                PopularDDLClassif();
                PopularDDLGenero();
            }

        }

        //popular gv2
        public void PopularGV2()
        {
            gv2.DataSource = objBLL.GetFilms_Film();
            gv2.DataBind();
        }

        //popular ddlClassif
        public void PopularDDLClassif()
        {
            ddlClassif.DataSource = objBLL.LoadDDLClassif_Classif();
            ddlClassif.DataBind();

        }

        //popular ddlGenero
        public void PopularDDLGenero()
        {
            ddlGenero.DataSource = objBLL.LoadDDLGenero_Genero();
            ddlGenero.DataBind();

        }

        //Search by name
        public void Search(string titulo)
        {
            titulo = txtSearch.Text.Trim();
            objDTO = objBLL.SearchByNameFilm(titulo);
            if (string.IsNullOrEmpty(titulo))
            {
                lblSearch.Text = "Campo vazio";
                txtSearch.Text = string.Empty;
                return;
            }
            else if (objDTO.Titulo == null)
            {
                lblSearch.Text = "Filme não cadastrado";
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                lblSearch.Text = string.Empty;
                txtId.Text = objDTO.Id.ToString();
                txtTitulo.Text = objDTO.Titulo.ToString();
                txtProdutora.Text = objDTO.Produtora.ToString();
                ddlClassif.SelectedValue = objDTO.Classificacao_Id.ToString();
                ddlGenero.SelectedValue = objDTO.Genero_Id.ToString();
                txtSearch.Text = string.Empty;
                txtTitulo.Focus();
            }
        }


        //search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string titulo = txtSearch.Text.Trim();
            Search(titulo);
        }

        //Select gv2
        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int filmeId = int.Parse(gv2.SelectedRow.Cells[1].Text);
            objDTO = objBLL.SearchByIdFilm(filmeId);
            txtId.Text = objDTO.Id.ToString();
            txtTitulo.Text = objDTO.Titulo.ToString();
            txtProdutora.Text = objDTO.Produtora.ToString();
            ddlClassif.SelectedValue = objDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = objDTO.Genero_Id.ToString();
            txtTitulo.Focus();
        }

        //validation
        public bool ValidaPage()
        {
            bool valid;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite o Titulo";
                txtTitulo.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Digite a Produtora";
                txtProdutora.Focus();
                valid = false;
            }
            else if (!Fup.HasFile)
            {
                lblFup.Text = "Selecione uma imagem";
                Fup.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        //Record
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {

                //Pegando as informaçoes do usuario
                objDTO.Titulo = txtTitulo.Text.Trim();
                objDTO.Produtora = txtProdutora.Text.Trim();
                objDTO.Classificacao_Id = ddlClassif.SelectedValue;
                objDTO.Genero_Id = ddlGenero.SelectedValue;
                //Imagem
                string str = Fup.FileName;
                Fup.PostedFile.SaveAs(Server.MapPath($"~/img/{str}"));
                string caminhoImg = $"~/img/{str}";
                objDTO.UrlImg = caminhoImg;

                //checando campo id
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    objBLL.CreateFilm(objDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O filme {objDTO.Titulo} foi cadastrado com sucesso";
                }
                else
                {
                    objDTO.Id = int.Parse(txtId.Text);
                    objBLL.UpdateFilm(objDTO);
                    PopularGV2();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O filme {objDTO.Titulo} foi editado com sucesso";
                }


            }
        }

        //Clear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtTitulo.Focus();
        }

        //Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objDTO.Id = int.Parse(txtId.Text);
            objBLL.DeleteFilm(objDTO.Id);
            PopularGV2();
            Clear.ClearControl(this);
            txtTitulo.Focus();
        }

        //FiltrarGVFilme
        public void FiltrarGVFilme()
        {
            string genero = txtFilters.Text;
            gv2.DataSource = objBLL.FilterByGenero(genero);
            gv2.DataBind();
        }

        //botao filtrar
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string genero = txtFilters.Text;
            var result = objBLL.FilterByGenero(genero);

            if (string.IsNullOrEmpty(txtFilters.Text) || (result.Count == 0))
            {
                Clear.ClearControl(this);
                lblFilter.ForeColor = System.Drawing.Color.Yellow;
                lblFilter.Text = "genero não existente";
                txtFilters.Focus();
                PopularGV2();
            }
            else
            {
                FiltrarGVFilme();
                Clear.ClearControl(this);
                txtFilters.Focus();
            }
        }

        //Botao limpar filtro
        protected void btnFilterClear_Click(object sender, EventArgs e)
        {
            PopularGV2();
            txtFilters.Text = string.Empty;
            txtFilters.Focus();
        }
    }
}