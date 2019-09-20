using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DDonah.AthosDesafio.Infra;
using DDonah.AthosDesafio.Infra.Generated;
using DDonah.AthosDesafio.Services;
using DDonah.AthosDesafio.WebApi.Config;
using DDonah.AthosDesafio.WebApi.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DDonah.AthosDesafio.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddCors();
            ConfigureDb(services);
            ConfigureScopedServices(services);
            ConfigureAutoMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors(option => option.AllowAnyOrigin());
        }

        private void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<AthosDesafioContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        private void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<IAdministradoraService, AdministradoraService>();
            services.AddScoped<ICondominioService, CondominioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
