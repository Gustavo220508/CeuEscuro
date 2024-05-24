using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.UI.utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.adm
{
    public partial class User : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objDTO = new UsuarioDTO();
        //carregamento da pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblSession.Text = $"Seja bem vindo {Session["Usuario"].ToString()} ao ceu escuro! Sua sessão inicia ás {DateTime.Now.ToString("t")}";
            //Response.AppendHeader("Refresh", String.Concat((Session.Timeout * 60), ";URL=../Login.aspx"));


            if (!IsPostBack)
            {
                txtId.Enabled = false;
                PopularGv1();
                PopularDDL1();
            }

        }

        //popular gv1
        public void PopularGv1()
        {
            gv1.DataSource = objBLL.GetUsers_User();
            gv1.DataBind();

        }

        //popular ddl1
        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.LoadDDL_TpUser();
            ddl1.DataBind();

        }

        //carrega dados
        public void Search(string nome)
        {
            nome = txtSearch.Text.Trim();
            objDTO = objBLL.SearchByNameUser(nome);
            if (string.IsNullOrEmpty(nome))
            {
                lblSearch.Text = "Campo vazio";
                txtSearch.Text = string.Empty;
                return;
            }
            else if (objDTO.Nome == null)
            {
                lblSearch.Text = "Usuario não cadastrado";
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                txtId.Text = objDTO.Id.ToString();
                txtNome.Text = objDTO.Nome.ToString();
                txtEmail.Text = objDTO.Email.ToString();
                txtSenha.Text = objDTO.Senha.ToString();
                txtDataNascUsuario.Text = objDTO.DataNascUsuario.ToString("dd/MM/yyyy");
                ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();
                txtSearch.Text = string.Empty;
                txtNome.Focus();
            }
        }

        //validation
        public bool ValidaPage()
        {
            bool valid;
            DateTime dt;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblNome.Text = "Digite o nome";
                txtNome.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblEmail.Text = "Digite o email";
                txtEmail.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                lblSenha.Text = "Digite a senha";
                txtSenha.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtDataNascUsuario.Text) || (!DateTime.TryParse(txtDataNascUsuario.Text, out dt)))
            {
                lblDataNascUsuario.Text = "Digite a data de nascimento";
                txtDataNascUsuario.Text = string.Empty;
                txtDataNascUsuario.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }

            return valid;
        }




        //btnSearch
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string nome = txtSearch.Text.Trim();
            Search(nome);
        }

        //gv1
        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(gv1.SelectedRow.Cells[1].Text);
            objDTO = objBLL.SearchById(usuarioId);
            txtId.Text = objDTO.Id.ToString();
            txtNome.Text = objDTO.Nome.ToString();
            txtEmail.Text = objDTO.Email.ToString();
            txtSenha.Text = objDTO.Senha.ToString();
            txtDataNascUsuario.Text = objDTO.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();
            PopularGv1();
        }

        //btnRecord
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {


                //preenchendo os dados fornecidos pelo usuario
                objDTO.Nome = txtNome.Text.Trim();
                objDTO.Email = txtEmail.Text.Trim();
                objDTO.Senha = txtSenha.Text.Trim();

                //ajustando a data
                DateTime dt = DateTime.Parse(txtDataNascUsuario.Text.Trim());
                objDTO.DataNascUsuario = dt;
                objDTO.TipoUsuario_Id = ddl1.SelectedValue;

                //checando o campo de id
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    objBLL.CreateUser(objDTO);
                    PopularGv1();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"Usuario {objDTO.Nome.ToUpper()} editado com sucesso";

                }
                else
                {
                    objDTO.Id = int.Parse(txtId.Text);
                    objBLL.UpdateUser(objDTO);
                    PopularGv1();
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"Usuario {objDTO.Nome.ToUpper()} editado com sucesso";
                }

            }

        }

        //btnDelete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objDTO.Id = int.Parse(txtId.Text);
            objBLL.DeleteUser(objDTO.Id);
            PopularGv1();
        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtSearch.Focus();
        }
    }
}