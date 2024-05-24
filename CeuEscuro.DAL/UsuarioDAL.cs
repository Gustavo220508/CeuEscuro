using CeuEscuro.DTO;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class UsuarioDAL : Conexao
    {
        //autenticar
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Nome, Senha, TipoUsuario_Id FROM Usuario WHERE Nome = @nome AND Senha = @senha", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@senha", senha);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.Nome = dr["Nome"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception($"Usuário não cadastrado na base ! {ex.Message}");
            }
            finally
            {
                Desconectar();
            }




        }

        //CRUD
        //Create
        public void CreateUser(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO Usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_Id) VALUES (@Nome,@Email,@Senha,@DataNascUsuario,@TipoUsuario_Id);", conn);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", usuario.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }

        //Read
        public List<UsuarioDTO> GetUsers()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Usuario.Id, Nome, Email,Senha, DataNascUsuario, Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.TipoUsuario_Id = TipoUsuario.Id; ", conn);
                dr = cmd.ExecuteReader();

                List<UsuarioDTO> Lista = new List<UsuarioDTO>();//Lista Vazia  

                while (dr.Read())
                {
                    UsuarioDTO usuario = new UsuarioDTO();
                    usuario.Id = Convert.ToInt32(dr["Id"]);
                    usuario.Nome = dr["Nome"].ToString();
                    usuario.Email = dr["Email"].ToString();
                    usuario.Senha = dr["Senha"].ToString();
                    usuario.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    usuario.TipoUsuario_Id = dr["Descricao"].ToString();
                    Lista.Add(usuario);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Update
        public void Update(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE Usuario SET Nome = @Nome, Email = @Email, Senha = @Senha,DataNascUsuario = @DataNascUsuario,TipoUsuario_Id = @TipoUsuario_Id WHERE Usuario.Id = @Usuario.Id;", conn);
                cmd.Parameters.AddWithValue("@Nome", usuario.nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", usuario.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
                cmd.Parameters.AddWithValue("@Usuario.Id", usuario.Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }

        //Delete
        public void Delete(int usuarioId)

        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM Usuario WHERE Usuario.Id = @Usuario.Id;", conn);
                cmd.Parameters.AddWithValue("@Usuario.Id", usuarioId);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //Search by Id
        public UsuarioDTO SearchById(int usuarioId)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Usuario WHERE Usuario.Id = @Usuario.Id ;", conn);
                cmd.Parameters.AddWithValue("@Usuario.Id", usuarioId);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.Id = Convert.ToInt32(dr["id"]);
                    usuario.Nome = dr["Nome"].ToString();
                    usuario.Email = dr["Email"].ToString();
                    usuario.Senha = dr["Senha"].ToString();
                    usuario.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();


                }
                return usuario;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }


        }

        //load DropDownList
        public List<TipoUsuarioDTO> LoadDDL()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> Lista = new List<TipoUsuarioDTO>();
                while (dr.Read())
                {
                    TipoUsuarioDTO tipoUsuario = new TipoUsuarioDTO();
                    tipoUsuario.Id = Convert.ToInt32(dr["Id"]);
                    tipoUsuario.Descricao = dr["Descricao"].ToString();
                    Lista.Add(tipoUsuario);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Search by Name

        public UsuarioDTO SearchByName(string nome)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Usuario WHERE Usuario.Nome = @Usuario.Nome ;", conn);
                cmd.Parameters.AddWithValue("@Usuario.Nome", nome);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();
                if (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.Id = Convert.ToInt32(dr["Id"]);
                    usuario.Nome = dr["Nome"].ToString();
                    usuario.Email = dr["Email"].ToString();
                    usuario.Senha = dr["Senha"].ToString();
                    usuario.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();


                }
                return usuario;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
    }
}