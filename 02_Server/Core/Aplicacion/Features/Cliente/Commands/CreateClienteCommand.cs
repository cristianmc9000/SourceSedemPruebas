using Aplicacion.DTOs;
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

namespace Aplicacion.Features.Cliente.Commands
{


    public class CreateClienteCommand : IRequest<Response<int>>
    {
        public FcClienteDto Cliente { get; set; }

    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<FcCliente> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateClienteCommandHandler(IRepositoryAsync<FcCliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<FcCliente>(request.Cliente);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdfcCliente);
        }


    }


}
