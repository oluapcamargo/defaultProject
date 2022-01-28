using Confluent.Kafka;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Entities;
using V1.DefaultProject.Domain.Interfaces;

namespace V1.DefaultProject.Functions.Functions
{
    public class FunctionCicloUpdateUser
    {
        private readonly IUsuarioRepository _homeRepositorio;

        public FunctionCicloUpdateUser(IUsuarioRepository homeRepositorio)
        {
            _homeRepositorio = homeRepositorio;
        }
        [FunctionName("FunctionCicloUpdateUser")]
        public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            var usuarios = (await _homeRepositorio.GetAllAsync()).ToList();
            if (usuarios == null)
            {
                usuarios = new List<Usuario>();
                usuarios.Add(new Usuario("Usuario Ciclo Update", "11111111111", "teste@tteste.com.br"));

                foreach (var item in usuarios)
                {
                    item.Nome += " - Function Ciclo" + DateTime.Now.ToShortDateString();
                    await _homeRepositorio.UpdateAsync(item);
                }
            }
        }
    }
}
