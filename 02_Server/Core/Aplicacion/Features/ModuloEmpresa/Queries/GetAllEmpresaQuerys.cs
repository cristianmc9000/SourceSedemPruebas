using Aplicacion.DTOs.ModuloEmpresa;
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


namespace Aplicacion.Features.ModuloEmpresa.Queries
{

    public class GetAllEmpresaQuery : IRequest<Response<List<PruebaEmpresaDto>>>
    {

        public class GetAllEmpresaQueryHandler : IRequestHandler<GetAllEmpresaQuery, Response<List<PruebaEmpresaDto>>>
        {
            private readonly IRepositoryAsync<PruebaEmpresa> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllEmpresaQueryHandler(IRepositoryAsync<PruebaEmpresa> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<PruebaEmpresaDto>>> Handle(GetAllEmpresaQuery request, CancellationToken cancellationToken)
            {
                var _Objeto = await _repositoryAsync.ListAsync();
                var _ObjetoDto = _mapper.Map<List<PruebaEmpresaDto>>(_Objeto);
                return new Response<List<PruebaEmpresaDto>>(_ObjetoDto);
            }
        }

    }
}
