using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    { 
        //choose one of two ways

        //public IVideoService GetVideoService()
        //{
        //    return new VideoService();
        //}

        public IVideoService VideoService
        {
            get
            {
                return new VideoService(new DALFacade());
            }
        }

        public IGenreService GenreService
        {
            get
            {
                return new GenreService(new DALFacade());
            }
        }

        public IProducerService ProducerService
        {
            get
            {
                return new ProducerService(new DALFacade());
            }
        }
    }
}

