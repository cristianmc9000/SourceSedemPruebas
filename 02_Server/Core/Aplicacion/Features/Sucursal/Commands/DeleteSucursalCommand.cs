using Aplicacion.Features.Cliente.Commands;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
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
    public class DeleteSucursalCommand : IRequest<Response<int>>
    {
        public int IdSucursal { get; set; }
    }

    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<FcSucursal> _repositoryAsync;
        public DeleteClienteCommandHandler(IRepositoryAsync<FcSucursal> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteSucursalCommand request, CancellationToken cancellationToken)
        {
            var _Sucursal = await _repositoryAsync.GetByIdAsync(request.IdSucursal);
            if (_Sucursal == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_Sucursal);
                return new Response<int>(_Sucursal.IdfcSucursal);
            }
        }

        public Task<Response<int>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
