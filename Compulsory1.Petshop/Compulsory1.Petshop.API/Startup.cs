using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Core.Services;
using Compulsory1.Petshop.Domain.IServices;
using Compulsory1.Petshop.Domain.Models;
using Compulsory1.Petshop.Infrastructure.Data;
using Compulsory1.Petshop.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Compulsory1.Petshop.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Compulsory1.Petshop.API", Version = "v1"});
            });
            services.AddDbContext<PetshopContext>(opt => opt.UseInMemoryDatabase("ThaDB"));
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetServices, PetService>();
            services.AddScoped<IPetTypeService, PetTypeServices>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compulsory1.Petshop.API v1"));

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetshopContext>();

                    ctx.PetTypes.Add(new PetType()
                    {
                        Id = 0,
                        Name = "Goat"
                    });
                    
                    ctx.Pets.Add(new Pet()
                    {
                        Id = 0,
                        Name = "Gertrud",
                        Birthdate = DateTime.Now,
                        SoldDate = DateTime.Today,
                        Color = "brown",
                        Price = 10.09,
                        PetType = ctx.PetTypes.SingleOrDefault(p=> p.Id == 0)
                    });
                    ctx.SaveChanges();

                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}