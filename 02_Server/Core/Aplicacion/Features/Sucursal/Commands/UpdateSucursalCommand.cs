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

    public class UpdateSucursalCommand : IRequest<Response<int>>
    {
        public int IdfcSucursal { get; set; }
        public int IdfcEmpresa { get; set; }
        public string DireccionSucursal { get; set; }
        public bool Estado { get; set; }
        public string UbicacionSucursal { get; set; }
        public string Telefono { get; set; }
        public string NombreSucursal { get; set; }
        public string IdcEstado { get; set; }
        public int? IdArea { get; set; }
        public int? IdfcCufd { get; set; }
        //TODO: agregar parametros
    }

    public class UpdateSucursalCommandHandler : IRequestHandler<UpdateSucursalCommand, Response<int>>
    {
        private IRepositoryAsync<FcSucursal> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateSucursalCommandHandler(IRepositoryAsync<FcSucursal> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateSucursalCommand request, CancellationToken cancellationToken)
        {
            var _Sucursal = await _repositoryAsync.GetByIdAsync(request.IdfcSucursal);
            if (_Sucursal == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _Sucursal.IdfcSucursal = request.IdfcSucursal;
                _Sucursal.DireccionSucursal = request.DireccionSucursal;
                _Sucursal.Estado = request.Estado;
                _Sucursal.UbicacionSucursal = request.UbicacionSucursal;
                _Sucursal.Telefono = request.Telefono;
                _Sucursal.NombreSucursal = request.NombreSucursal;
                _Sucursal.IdfcSucursal = request.IdfcSucursal;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_Sucursal);
                return new Response<int>(_Sucursal.IdfcSucursal);
            }
        }

      
    }

   
}
