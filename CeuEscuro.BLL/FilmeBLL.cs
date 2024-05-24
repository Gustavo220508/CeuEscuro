using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class FilmeBLL
    {
        //objeto para acessar os recursos da camada DAL
        FilmeDAL objBLL = new FilmeDAL();



        //CRUD
        //Create
        public void CreateFilm(FilmeDTO filme)
        {
            objBLL.CreateUser(filme);
        }

        //Read
        public List<FilmeDTO> GetFilms_Film()
        {
            return objBLL.GetFilms();
        }

        //Update
        public void UpdateFilm(FilmeDTO filme)
        {
            objBLL.Update(filme);
        }

        //Delete
        public void DeleteFilm(int filmeId)
        {
            objBLL.DeleteFilm(filmeId);
        }

        //Search by Id
        public FilmeDTO SearchByIdFilm(int filmeId)
        {
            return objBLL.SearchById(filmeId);
        }

        //Load DropDownListClassif
        public List<ClassificacaoDTO> LoadDDLClassif_Classif()
        {
            return objBLL.LoadDDLClassif();
        }

        //Load DropDownListGenero
        public List<GeneroDTO> LoadDDLGenero_Genero()
        {
            return objBLL.LoadDDLGenero();
        }


        //Search by Name
        public FilmeDTO SearchByNameFilm(string titulo)
        {
            return objBLL.SearchByName(titulo);

        }

        //Filter
        public List<FilmeDTO> FilterByGenero(string genero)
        {
            return objBLL.FilterByGenero(genero);
        }

    }
}
