using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL.Services
{
    public interface IGenreService
    { 
                //C
    GenreBO Create(GenreBO genre);
    List<GenreBO> CreateGenres(List<GenreBO> listOfGenres);
    //R
    List<GenreBO> GetAll();
    GenreBO Get(int Id);
    //U
    GenreBO Update(GenreBO genre);
    //D
    GenreBO Delete(int Id);
}
}
