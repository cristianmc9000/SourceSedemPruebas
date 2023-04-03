using Aplicacion.DTOs;
using Aplicacion.DTOs.ModuloPersona;
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

namespace Aplicacion.Features.ModuloPersona.Commands
{

    public class DeletePersonaCommand : IRequest<Response<int>>
    {
        public int IdPersona { get; set; }
    }

    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PruebaPersona> _repositoryAsync;
        public DeletePersonaCommandHandler(IRepositoryAsync<PruebaPersona> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var _Persona = await _repositoryAsync.GetByIdAsync(request.IdPersona);
            if (_Persona == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_Persona);
                return new Response<int>(_Persona.IdPersona);
            }
        }
    }
}
