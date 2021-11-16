using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KursusProgram.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KursusProgram {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.

        public Startup(IConfiguration config) {
            Configuration = config;
        }
        public IConfiguration Configuration { get; set; }    
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddDbContext<KursusDbContext>(opts => {
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:KursusConnection"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();


            });
        }
    }
}
