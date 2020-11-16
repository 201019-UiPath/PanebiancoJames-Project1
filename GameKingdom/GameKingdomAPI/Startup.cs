using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GameKingdomDB;
using GameKingdomDB.Entities;
using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using GameKingdomDB.Mappers;
using GameKingdomLib;

namespace GameKingdomAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddControllers();
            services.AddDbContext<GameKingdomContext>(options => options.UseNpgsql(Configuration.GetConnectionString("GameKingdomDB")));

            services.AddScoped<CustomerService>();
            services.AddScoped<InventoryService>();
            services.AddScoped<LocationService>();
            services.AddScoped<ManagerService>();
            services.AddScoped<OrderItemService>();
            services.AddScoped<OrderService>();
            services.AddScoped<ProductService>();

            services.AddScoped<ICustomerRepo, DBRepo>();
            services.AddScoped<IInventoryRepo, DBRepo>();
            services.AddScoped<ILocationRepo, DBRepo>();
            services.AddScoped<IManagerRepo, DBRepo>();
            services.AddScoped<IOrderItemsRepo, DBRepo>();
            services.AddScoped<IOrderRepo, DBRepo>();
            services.AddScoped<IProductRepo, DBRepo>();

            services.AddScoped<IMapper, DBMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
