using Aplicacion.DTOs;
using Aplicacion.DTOs.ModuloPerpas;
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

namespace Aplicacion.Features.ModuloPerpas.Commands
{

    public class DeletePerpasCommand : IRequest<Response<int>>
    {
        public int IdPersona { get; set; }
    }

    public class DeletePerpasCommandHandler : IRequestHandler<DeletePerpasCommand, Response<int>>
    { 
        private readonly IRepositoryAsync<PruebaPerpas> _repositoryAsync;
        public DeletePerpasCommandHandler(IRepositoryAsync<PruebaPerpas> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeletePerpasCommand request, CancellationToken cancellationToken)
        {
            var _Persona = await _repositoryAsync.GetByIdAsync(request.IdPersona);
            if (_Persona == null)
            {
                throw new KeyNotFoundException("Registro no encontrado con el id");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(_Persona);
                return new Response<int>(_Persona.PersonaIdPersona * 1000 + _Persona.PasatiempoIdPasatiempo);
            }
        }
    }
}
