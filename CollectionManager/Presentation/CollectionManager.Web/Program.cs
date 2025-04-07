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
            // Commonly used MVC services
            _ = builder.Services.AddControllersWithViews();

            return builder;
        }

        private static WebApplicationBuilder RegisterAppServices(this WebApplicationBuilder builder)
        {
            return builder;
        }
        #endregion

        #region Configure HTTP Request pipeline
        private static WebApplication ConfigureHttpRequestPipeine(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                _ = app.UseHsts();  // Default: 30 days
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.MapStaticAssets();
            _ = app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
                   .WithStaticAssets();

            return app;
        }
        #endregion
    }
}