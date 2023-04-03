using Aplicacion.DTOs;
using Aplicacion.DTOs.Cliente;
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
	public class CreatePersonaCommand : IRequest<Response<int>>
	{
		public PruebaPersonaDto persona { get; set; }

	}

	public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, Response<int>>
	{
		private readonly IRepositoryAsync<PruebaPersona> _repositoryAsync;
		private readonly IMapper _mapper;
		public CreatePersonaCommandHandler(IRepositoryAsync<PruebaPersona> repositoryAsync, IMapper mapper)
		{
			_repositoryAsync = repositoryAsync;
			_mapper = mapper;
		}

		public async Task<Response<int>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
		{
			var nuevoRegistro = _mapper.Map<PruebaPersona>(request.persona);
			var data = await _repositoryAsync.AddAsync(nuevoRegistro);
			return new Response<int>(data.IdPersona);
		}

		
	}

    //Validador..
    public class CreatePersonaCommandValidator : AbstractValidator<CreatePersonaCommand>
    {
        public CreatePersonaCommandValidator()
        {
            RuleFor(p => p.persona.Nombres)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
            RuleFor(p => p.persona.Paterno)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
            RuleFor(p => p.persona.Materno)
                //.NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
            RuleFor(p => p.persona.LugarNacimiento)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(p => p.persona.FechaNacimiento)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            //.MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
            RuleFor(p => p.persona.IdEmpresa)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
        }
    }


}
