using Microsoft.Azure.WebJobs;
using System;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;

namespace V1.DefaultProject.FunctionsAzure.Functions
{
    public class FunctionQueueCicloUpdateUser
    {
        private readonly IUsuarioRepository _homeRepositorio;

        public FunctionQueueCicloUpdateUser(IUsuarioRepository homeRepositorio)
        {
            _homeRepositorio = homeRepositorio;
        }
        [FunctionName("FunctionQueueCicloUpdateUser")]
        public async Task Run([QueueTrigger("queue-update-user", Connection = "StorageConnectionString")] Guid input)
        {
            Console.WriteLine("FunctionCicloUpdateUser Iniciada");

            var usuario = await _homeRepositorio.GetAsync(input);
            usuario.Nome += " - Function Queue" + DateTime.Now.ToShortDateString();
            await _homeRepositorio.UpdateAsync(usuario);
            Console.WriteLine("FunctionCicloUpdateUser Finalizada");

        }
    }
}
