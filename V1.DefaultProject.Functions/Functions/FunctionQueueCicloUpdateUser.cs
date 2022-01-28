using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;

namespace V1.DefaultProject.Functions.Functions
{
    public class FunctionQueueCicloUpdateUser
    {
        private readonly IUsuarioRepository _homeRepositorio;

        public FunctionQueueCicloUpdateUser(IUsuarioRepository homeRepositorio)
        {
            _homeRepositorio = homeRepositorio;
        }
        [FunctionName("FunctionCicloUpdateUser")]
        public async Task Run([QueueTrigger("queue-update-user", Connection = "StorageConnectionString")] Guid input)
        {
            var usuario = await _homeRepositorio.GetAsync(input);
            usuario.Nome += " - Function Queue" + DateTime.Now.ToShortDateString();
            await _homeRepositorio.UpdateAsync(usuario);
        }
    }
}
