using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PokedexApi.Models;
using PokedexApi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pokedex
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
            var path = XmlCommentsFilePath;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }

        public string XmlCommentsFilePath
        {
            get
            {
                var basePath = Env.ContentRootPath;
                var fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                return Path.Combine(AppContext.BaseDirectory, fileName);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {              
                // c.EnableAnnotations();
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "pokedex", Version = "v1",Description="Pokemon Api that allows user to get basic pokemon information along with it's translated description" });
            });

            services.Configure<PokemonApiSettings>(Configuration.GetSection("PokemonApi"));
            services.Configure<TranslationApiSettings>(Configuration.GetSection("TranslationApi"));


            services.AddHttpClient<IPokemonService, PokemonService>();
               
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "pokedex v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
