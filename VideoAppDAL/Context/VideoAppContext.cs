using VideoAppDAL.Entities;
using VideoAppUI.VideoAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

//using Microsoft.Data.Entity;

namespace VideoAppDAL.Context
{
    class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options = new DbContextOptionsBuilder<VideoAppContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //what we want in the memoryDb
        /*public VideoAppContext() : base(options)
        {

        }*/


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=tcp:videoapp-moystre.database.windows.net,1433;Initial Catalog=VideoAppDB;Persist Security Info=False;User ID=moystre;Password=zaq1@WSXCDE#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
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
