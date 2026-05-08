using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Models;

namespace MovieApp.Web
{
    public class Startup
    {
        // 1. YENİ EKLENEN KISIM: Configuration nesnesini sisteme tanıtıyoruz
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // 2. Senin yazdığın ConfigureServices kısmı (Buraya hiç dokunma, sende zaten var)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // YENİ EKLENEN VERİTABANI KÖPRÜSÜ
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Statik dosyaları (CSS, Resim vb.) kullanabilmek için
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Hangi sayfanın önce açılacağını belirliyoruz
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}