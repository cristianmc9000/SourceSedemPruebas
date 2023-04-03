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

namespace Aplicacion.Features.ModuloEmpresa.Commands
{


    public class UpdateEmpresaCommand : IRequest<Response<int>>
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        //TODO: agregar parametros
    }

    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, Response<int>>
    {
        private IRepositoryAsync<PruebaEmpresa> _repositoryAsync;
        private readonly IMapper _mapper;
        public UpdateEmpresaCommandHandler(IRepositoryAsync<PruebaEmpresa> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var _Empresa = await _repositoryAsync.GetByIdAsync(request.IdEmpresa);
            if (_Empresa == null)
            {
                throw new KeyNotFoundException("Registro no encontrado");
            }
            else
            {
                _Empresa.IdEmpresa = request.IdEmpresa;
                _Empresa.Nombre = request.Nombre;
                _Empresa.Departamento = request.Departamento;
                //TODO: agregar mas propiedades

                await _repositoryAsync.UpdateAsync(_Empresa);
                return new Response<int>(_Empresa.IdEmpresa);
            }
        }

    }

}
