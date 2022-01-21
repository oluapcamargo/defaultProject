using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.Util;
using V1.DefaultProject.Domain.ViewModels.Output.Home;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.Queries.HomeQueries
{
    public partial class QueryGetHomeCommandHandler
    {
        private readonly IHomeRepository _repository;
        public QueryGetHomeCommandHandler(IHomeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<HomeListOutput>> Get()
        {
            var result = new Result<HomeListOutput>();
            var list = await _repository.GetAllAsync();
            result.Value = new HomeListOutput()
            {
                Qtd = list.ToList().Count(),
                data = list.Select(x => new HomeOutput { Desenvolvedor = x.Desenvolvedor, DataCriacao = Tools.FormatarData(x.DataCriacao) })
            };
            return result;
        }
    }
}
