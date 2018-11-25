using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Services.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Helpers;
using BookingAPI.Services.Helpers;
using BookingAPI.Services.Interfaces;
using BookingAPI.Data.Helpers;

namespace BookingAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //string dbConnString = Configuration.GetConnectionString("candidate");

            services.AddSingleton(_ => new ApiValidator(10));
            services.AddTransient<IReservationMapper, ReservationMapper>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            string dbConnString = @"Server=SUVETHAN-PC;Database=BookingDB;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<BookingContext>();
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
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
