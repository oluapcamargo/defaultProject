using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using V1.DefaultProject.Application.Commands.HomeCommands;
using V1.DefaultProject.Application.Commands.UsuarioCommands;
using V1.DefaultProject.Config.Extension;
using V1.DefaultProject.Domain.Queries.HomeQueries;
using V1.DefaultProject.Domain.Queries.UsuarioQueries;

namespace V1.DefaultProject.Functions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 }).ConfigureServices((hostContext, services) =>
                 {
                     services.ConfigureDbContext(hostContext.Configuration);

                    //Home
                    services.AddMediatR(typeof(QueryGetByIdHomeCommandHandler));
                     services.AddMediatR(typeof(QueryGetHomeCommandHandler));
                     services.AddMediatR(typeof(CommandSalvarHomeHandler));
                     services.AddMediatR(typeof(CommandAtivarouDesativarHomeHandler));
                     services.AddMediatR(typeof(CommandAtualizarHomeHandler));

                    //Usuario
                    services.AddMediatR(typeof(QueryGetByIdUsuarioCommandHandler));
                     services.AddMediatR(typeof(QueryGetUsuarioCommandHandler));
                     services.AddMediatR(typeof(CommandSalvarUsuarioHandler));
                     services.AddMediatR(typeof(CommandAtivarouDesativarUsuarioHandler));
                     services.AddMediatR(typeof(CommandAtualizarUsuarioHandler));
                 });
    }
}
