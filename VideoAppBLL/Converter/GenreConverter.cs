using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    class GenreConverter
    {
        internal Genre Convert(GenreBO genreBO)
        {
            if (genreBO == null) { return null;  }
            return new Genre()
            {
                Id = genreBO.Id,
                Name = genreBO.Name,
                //Video = new VideoConverter().Convert(genreBO.Video),
                VideoId = genreBO.VideoId
            };
        }

        internal GenreBO Convert(Genre genre)
        {
            if (genre == null) { return null; }
            return new GenreBO()
        {
            Id = genre.Id,
            Name = genre.Name, 
            Video = new VideoConverter().Convert(genre.Video),
            VideoId = genre.VideoId
            };
        }
    }
}

