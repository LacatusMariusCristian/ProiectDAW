using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Contexts;
using ProiectMDS.Repositories.AlbumRepositories;
using ProiectMDS.Repositories.ArtistAlbumRepository;
using ProiectMDS.Repositories.ArtistRepository;
using ProiectMDS.Repositories.ProviderRepository;
using ProiectMDS.Repositories.SongAlbumRepository;
using ProiectMDS.Repositories.SongRepository;
using ProiectMDS.Repositories.StudioRepository;

namespace ProiectMDS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IArtistAlbumRepository, ArtistAlbumRepository>();
            services.AddTransient<IStudioRepository, StudioRepository>();
            services.AddTransient<IProviderRepository, ProviderRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<ISongAlbumRepository, SongAlbumRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials());
            app.UseMvc();
        }
    }
}
