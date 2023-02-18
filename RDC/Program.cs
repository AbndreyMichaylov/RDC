using Microsoft.EntityFrameworkCore;
using RDC.src.Apis.Bases;
using RDC.src.Apis.MouseApi;
using RDC.src.Data.Database;
using RDC.src.Data.MouseRepository;

namespace RDC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            RegisterServices(builder.Services, builder);

            var app = builder.Build();

            Configure(app);


            //Registrer all endpoints in all apis
            var apis = app.Services.GetServices<IApi>();
            foreach (var api in apis)
            {
                if (api is null) throw new InvalidProgramException("Api not found");
                api.Register(app);
            }

            app.Run();

        }

        private static void RegisterServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDb>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
            });

            services.AddScoped<IMouseRepository, MouseRepository>();
            services.AddTransient<IApi, MouseApi>();
        }

        private static void Configure(WebApplication app) 
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}