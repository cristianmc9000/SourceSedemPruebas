using Aplicacion.DTOs.Sucursal;
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

namespace Aplicacion.Features.Sucursal.Queries
{


    public class GetAllSucursalQuery : IRequest<Response<List<FcSucursalDto>>>
    {
    


        public class GetAllSucursalQueryHandler : IRequestHandler<GetAllSucursalQuery, Response<List<FcSucursalDto>>>
        {
            private readonly IRepositoryAsync<FcSucursal> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllSucursalQueryHandler(IRepositoryAsync<FcSucursal> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<FcSucursalDto>>> Handle(GetAllSucursalQuery request, CancellationToken cancellationToken)
            {
                var _Sucursal = await _repositoryAsync.ListAsync();
                var _SucursalDto = _mapper.Map<List<FcSucursalDto>>(_Sucursal);
                return new Response<List<FcSucursalDto>>(_SucursalDto);
            }

        }

    }

}
