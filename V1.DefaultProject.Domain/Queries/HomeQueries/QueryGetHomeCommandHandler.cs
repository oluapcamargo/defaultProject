using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.Util;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Domain.ViewModels.Output.Home;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;

namespace V1.DefaultProject.Domain.Queries.HomeQueries
{
    public partial class QueryGetHomeCommandHandler : IRequestHandler<ObterHomeInput, Result<HomeListOutput>>
    {
        private readonly IHomeRepository _repository;
        public QueryGetHomeCommandHandler(IHomeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<HomeListOutput>> Handle(ObterHomeInput input , CancellationToken cancellationToken)
        {
            var result = new Result<HomeListOutput>();
            var list = await _repository.GetAll(input);
            result.Value = new HomeListOutput()
            {
                Qtd = list.ToList().Count(),
                data = list.Select(x => new HomeOutput { Desenvolvedor = x.Desenvolvedor, DataCriacao = Tools.FormatarData(x.DataCriacao) , Codigo = x.Codigo})
            };
            return result;
        }
    }
}
