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


    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        public int IdfcCliente { get; set; }
        public string NitCarnet { get; set; }
        public string Cliente { get; set; }
        //TODO: agregar parametros
    }

    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
    {
        private IRepositoryAsync<FcCliente> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateClienteCommandHandler(IRepositoryAsync<FcCliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var _Cliente = await _repositoryAsync.GetByIdAsync(request.IdfcCliente);
            if (_Cliente == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _Cliente.IdfcCliente = request.IdfcCliente;
                _Cliente.NitCarnet = request.NitCarnet;
                _Cliente.Cliente = request.Cliente;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_Cliente);
                return new Response<int>(_Cliente.IdfcCliente);
            }
        }

    }

}
