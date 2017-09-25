using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Context
{
    class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options = new DbContextOptionsBuilder<VideoAppContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //what we want in the memoryDb
        public VideoAppContext() : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
