using Aplicacion.DTOs;
using Aplicacion.DTOs.ModuloEmpresa;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Features.ModuloEmpresa.Commands
{

    public class DeleteEmpresaCommand : IRequest<Response<int>>
    {
        public int IdEmpresa { get; set; }
    }

    public class DeleteEmpresaCommandHandler : IRequestHandler<DeleteEmpresaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PruebaEmpresa> _repositoryAsync;
        public DeleteEmpresaCommandHandler(IRepositoryAsync<PruebaEmpresa> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
        {
            var _Empresa = await _repositoryAsync.GetByIdAsync(request.IdEmpresa);
            if (_Empresa == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_Empresa);
                return new Response<int>(_Empresa.IdEmpresa);
            }
        }
    }
}
