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

namespace Aplicacion.Features.Sucursal.Commands
{

    public class CreateSucursalCommand : IRequest<Response<int>>
    {
        public FcSucursalDto Sucursal { get; set; }
    }

    public class CreateSucursalCommandHandler : IRequestHandler<CreateSucursalCommand, Response<int>>
    {
        private readonly IRepositoryAsync<FcSucursal> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateSucursalCommandHandler(IRepositoryAsync<FcSucursal> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSucursalCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<FcSucursal>(request.Sucursal);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdfcSucursal);
        }
    }
     
}
