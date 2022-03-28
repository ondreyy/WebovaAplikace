using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace WebovaAplikace
{
    class Program
    {
        static void Main(string[] args)
        {
            // vytvoreni tvorice aplikace
            var builder = WebApplication.CreateBuilder(args);

            // nastaveni tvorice aplikace
            builder.Services.AddControllersWithViews();


            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".WebovaAplikace";
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });

            // vytvoreni aplikace
            var app = builder.Build();

            // nastaveni aplikace
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // spusteni aplikace
            app.Run();
        }
    }
}
