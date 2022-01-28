using Microsoft.Extensions.DependencyInjection;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Persistence.Repository.Home;
using V1.DefaultProject.Persistence.Repository.Usuario;

namespace V1.DefaultProject.Config.Extension
{
    public static class ConfigureServicesCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services) 
        {
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
