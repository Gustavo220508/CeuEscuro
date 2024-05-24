using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DTO
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Produtora { get; set; }
        public string UrlImg { get; set; }
        public string Classificacao_Id { get; set; }
        public string Genero_Id { get; set; }
    }
}
