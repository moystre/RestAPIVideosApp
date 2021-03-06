﻿using VideoAppDAL.Context;
using VideoAppDAL.Repositories;

namespace VideoAppDAL.UOW
{
    class UnitOfWorkMemory : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        public IGenreRepository GenreRepository { get; internal set; }
        public IProducerRepository ProducerRepository { get; internal set; }

        private VideoAppContext context;

        public UnitOfWorkMemory()
        {
            context = new VideoAppContext();
            context.Database.EnsureCreated();
            VideoRepository = new VideoRepository(context);
            GenreRepository = new GenreRepository(context);
            ProducerRepository = new ProducerRepository(context);
        }

        public int Complete()
        {
            //number of objects written to the underlying db
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
