using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Text;

namespace V1.DefaultProject.FunctionsAzure.Util
{
    public static class DefaultProjectQueueOptions
    {
        public static void SetQueuesOptions(QueuesOptions options)
        {
            //O número de mensagens em fila que o runtime de Funções recupera simultaneamente e processa em paralelo (Padrão 16).
            options.BatchSize = Convert.ToInt32(Environment.GetEnvironmentVariable("QueuesOptions:BatchSize"));

            //Sempre que o número de mensagens processadas simultaneamente chega a esse número, o runtime recupera outro lote (Padrão batchSize/2).
            options.NewBatchThreshold = Convert.ToInt32(Environment.GetEnvironmentVariable("QueuesOptions:NewBatchThreshold"));

            //O intervalo máximo entre as sondagens de fila (Padrão 00:00:01).
            options.MaxPollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("QueuesOptions:MaxPollingIntervalSeg")));

            //O número de vezes para tentar processar uma mensagem antes de movê-la para a fila de mensagens suspeitas (Padrão 5).
            options.MaxDequeueCount = Convert.ToInt32(Environment.GetEnvironmentVariable("QueuesOptions:MaxDequeueCount"));

            //O intervalo de tempo entre as repetições quando o processamento de uma mensagem falha (Padrão 00:00:00).
            options.VisibilityTimeout = TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("QueuesOptions:VisibilityTimeoutSeg")));
        }
    }
}
