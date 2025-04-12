using CollectionManager.Logic.Managers;
using CollectionManager.Logic.Managers.Interfaces;
using CollectionManager.SQLServer.Context;
using CollectionManager.SQLServer.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.Web
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            WebApplication.CreateBuilder(args)
                // Services
                .RegisterNetServices()
                .RegisterAppServices()
                .Build()
                // Configuration
                .ConfigureHttpRequestPipeine()
                .Run();
        }

        #region Dependency Injection (DI)
        private static WebApplicationBuilder RegisterNetServices(this WebApplicationBuilder builder)
        {
            #region Entity Framework | SQL Server
            // Load secrets.json
            builder.Configuration.AddUserSecrets("b50d7c49-0d78-45fb-bae6-5a3f782d964b");

            // Retrieve connection string
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentException($"Specified database connection string cannot be found");

            // Register SQL Server database
            builder.Services.AddDbContext<CollectionManagerDbContext>(options
                => options.UseSqlServer(connectionString, optionsBuilder
                => optionsBuilder.MigrationsAssembly("CollectionManager.SQLServer")));

            builder.Services.AddScoped<ICollectionManagerDbContext, CollectionManagerDbContext>();
            #endregion

            #region ASP.NET MVC
            // Commonly used MVC services
            builder.Services.AddControllersWithViews();
            #endregion

            return builder;
        }

        private static WebApplicationBuilder RegisterAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICrudManager, CrudManager>();

            return builder;
        }
        #endregion

        #region Configure HTTP Request pipeline
        private static WebApplication ConfigureHttpRequestPipeine(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();  // Default: 30 days
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
               .WithStaticAssets();

            return app;
        }
        #endregion
    }
}