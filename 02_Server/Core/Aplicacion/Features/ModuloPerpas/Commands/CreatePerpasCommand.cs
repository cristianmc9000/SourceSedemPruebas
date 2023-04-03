using Aplicacion.DTOs;
using Aplicacion.DTOs.Cliente;
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
    public class CreatePerpasCommand : IRequest<Response<int>>
    {
        public PruebaPerpasDto perpas { get; set; }
    }

    public class CreatePerpasCommandHandler : IRequestHandler<CreatePerpasCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PruebaPerpas> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreatePerpasCommandHandler(IRepositoryAsync<PruebaPerpas> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePerpasCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<PruebaPerpas>(request.perpas);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.PersonaIdPersona * 1000 + data.PasatiempoIdPasatiempo);
        }
    }



    public class CreatePerpasCommandValidator : AbstractValidator<CreatePerpasCommand>
    {
        public CreatePerpasCommandValidator()
        {
            RuleFor(p => p.perpas.IdPersona)
                .NotEmpty().WithMessage("{PropertyName} no pude ser vacio");
            RuleFor(p => p.perpas.IdPasatiempo)
                .NotEmpty().WithMessage("{PropertyName} no pude ser vacio");

        }
    }

}
