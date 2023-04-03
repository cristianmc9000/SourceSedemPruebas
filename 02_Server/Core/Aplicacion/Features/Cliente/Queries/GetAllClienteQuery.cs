using Aplicacion.DTOs.Cliente;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.Cliente.Queries
{

    public class GetAllClienteQuery : IRequest<Response<List<FcClienteDto>>>
    {


        public class GetAllClienteQueryHandler : IRequestHandler<GetAllClienteQuery, Response<List<FcClienteDto>>>
        {
            private readonly IRepositoryAsync<FcCliente> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllClienteQueryHandler(IRepositoryAsync<FcCliente> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<FcClienteDto>>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
            {
                var _Cliente = await _repositoryAsync.ListAsync();
                var _ClienteDto = _mapper.Map<List<FcClienteDto>>(_Cliente);
                return new Response<List<FcClienteDto>>(_ClienteDto);
            }

        }

    }


}
