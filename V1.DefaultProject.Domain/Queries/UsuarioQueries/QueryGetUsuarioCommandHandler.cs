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
using V1.DefaultProject.Domain.ViewModels.Output.Usuario;
using V1.DefaultProject.Domain.ViewModels.Output.ResultView;
using V1.DefaultProject.Domain.ViewModels.Input.Usuario;

namespace V1.DefaultProject.Domain.Queries.UsuarioQueries
{
    public partial class QueryGetUsuarioCommandHandler : IRequestHandler<ObterUsuarioInput, Result<UsuarioListOutput>>
    {
        private readonly IUsuarioRepository _repository;
        public QueryGetUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<UsuarioListOutput>> Handle(ObterUsuarioInput input , CancellationToken cancellationToken)
        {
            var result = new Result<UsuarioListOutput>();
            var list = await _repository.GetAllAsync();
            result.Value = new UsuarioListOutput()
            {
                Qtd = list.ToList().Count(),
                data = list
            };
            return result;
        }
    }
}
