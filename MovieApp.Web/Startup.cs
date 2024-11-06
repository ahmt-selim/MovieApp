using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options =>
            //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {//Uygulama geli�tirme a�amas�nda oldu�u bilgisini:
                //Properties klas�r�ne �ift t�klayarak Debug k�sm�nda Environment variables k�sm�ndan ayarlayabiliriz.
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);//Uygulama geli�tirme a�amas�nda veritaban�na eklenecek test verilerinin olu�turuldu�u class
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "home",
                //    pattern: "",
                //    defaults: new { controller = "Home", action = "Index" });
                //endpoints.MapControllerRoute(
                //    name: "about",
                //    pattern: "about",
                //    defaults: new { controller = "Home", action = "About" });
                //endpoints.MapControllerRoute(
                //    name: "movieList",
                //    pattern: "movies",
                //    defaults: new { controller = "Movies", action = "List" });
                //endpoints.MapControllerRoute(
                //    name: "movieDetails",
                //    pattern: "movies/details",
                //    defaults: new { controller = "Movies", action = "Details" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
