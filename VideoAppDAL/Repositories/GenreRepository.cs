using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class GenreRepository : IGenreRepository
    {
        VideoAppContext _context;
        public GenreRepository(VideoAppContext context)
        {
            _context = context;
        }
        public Genre Create(Genre genre)
        {
            //if(genre.Video != null)
            //{
            //    _context.Entry(genre.Video).State = EntityState.Unchanged;
            //}
            _context.Genres.Add(genre);
            return genre;
        }

        public Genre Delete(int Id)
        {
            var genre = Get(Id);
            _context.Genres.Remove(genre);
            return genre;
        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(o => o.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}
