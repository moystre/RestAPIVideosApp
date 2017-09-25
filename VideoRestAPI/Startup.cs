using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoAppBLL;
using VideoAppBLL.BusinessObjects;
using VideoAppUI.VideoAppBLL.BusinessObjects;

namespace VideoRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                var prod1 = facade.ProducerService.Create(new ProducerBO()
                {
                    Name = "Producer1",
                    Location = "City00010"
                });

                var vid1 = facade.VideoService.Create(new VideoBO()
                {
                    Title = "video1",
                    Duration = 234,
                    Genre = "genre1",
                    Producers = new List<ProducerBO>() { prod1 }
                });

                var vid2 = facade.VideoService.Create(new VideoBO()
                {
                    Title = "video2",
                    Duration = 24,
                    Genre = "genre2"
                });

                var vid3 = facade.VideoService.Create(new VideoBO()
                {
                    Title = "video3",
                    Duration = 242,
                    Genre = "genre3"
                });

                

                facade.GenreService.Create(new GenreBO()
                {
                    Name = "genre1",
                    Video = vid1,
                    VideoId = vid1.Id
                });

                facade.GenreService.Create(new GenreBO()
                {
                    Name = "genre2",
                    Video = vid2
                });

                facade.GenreService.Create(new GenreBO()
                {
                    Name = "genre3",
                    Video = vid3
                });

                
            }

            app.UseMvc();

            //

            
        }
    }
}
