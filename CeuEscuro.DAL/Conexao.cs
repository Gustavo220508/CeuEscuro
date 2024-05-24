using CeuEscuro.DTO;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class Conexao
    {
        //variaveis
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader dr;

        public void CreateUser(FilmeDTO filme)
        {
            throw new NotImplementedException();
        }

        public void Update(FilmeDTO filme)
        {
            throw new NotImplementedException();
        }

        //metodos
        protected void Conectar() 
        {
            try
            {
                conn = new MySqlConnection("Data Source = localhost; Initial Catalog = CeuEscuroDB; Uid = root; Pwd = ;");
                conn.Open();

            }
            catch (Exception ex)
            {

                throw new Exception($"Deu problema na conexão !!!{ex.Message}");
            }

        }

        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
