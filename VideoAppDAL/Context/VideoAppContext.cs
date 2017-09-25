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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //building a combined primarykey 
            modelBuilder.Entity<VideoProducer>()
                .HasKey(vp => new { vp.VideoId, vp.ProducerId });
            base.OnModelCreating(modelBuilder);

            //foreign key
            modelBuilder.Entity<VideoProducer>()
                .HasOne(vp => vp.Producer)
                .WithMany(p => p.Videos)
                .HasForeignKey(vp => vp.ProducerId);

            //foreign key
            modelBuilder.Entity<VideoProducer>()
                .HasOne(vp => vp.Video)
                .WithMany(v => v.Producers)
                .HasForeignKey(vp => vp.VideoId);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
