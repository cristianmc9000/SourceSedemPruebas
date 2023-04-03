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


	public class UpdatePersonaCommand : IRequest<Response<int>>
	{
		public int IdPersona { get; set; }
		public string FechaNacimiento { get; set; }
		public string LugarNacimiento { get; set; }
		public int IdEmpresa { get; set; }
		public string Nombres { get; set; }
		public string Paterno { get; set; }
		public string Materno { get; set; }
		//TODO: agregar parametros
	}

	public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, Response<int>>
	{
		private IRepositoryAsync<PruebaPersona> _repositoryAsync;
		private readonly IMapper _mapper;
		public UpdatePersonaCommandHandler(IRepositoryAsync<PruebaPersona> repositoryAsync, IMapper mapper)
		{
			_repositoryAsync = repositoryAsync;
			_mapper = mapper;
		}

		public async Task<Response<int>> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
		{
			var _Persona = await _repositoryAsync.GetByIdAsync(request.IdPersona);
			if (_Persona == null)
			{
				throw new KeyNotFoundException("Registro no encontrado");
			}
			else
			{
				_Persona.IdPersona = request.IdPersona;
				_Persona.Nombres = request.Nombres;
				_Persona.Paterno = request.Paterno;
				_Persona.Materno = request.Materno;
				_Persona.IdEmpresa = request.IdEmpresa;
				_Persona.FechaNacimiento = request.FechaNacimiento;
				_Persona.LugarNacimiento = request.LugarNacimiento;
				//TODO: agregar mas propiedades

				await _repositoryAsync.UpdateAsync(_Persona);
				return new Response<int>(_Persona.IdPersona);
			}
		}

	}
    public class UpdatePersonaCommandValidator : AbstractValidator<UpdatePersonaCommand>
    {

        public UpdatePersonaCommandValidator()
        {
            //TODO: agregar regla de validaciones ..
            RuleFor(p => p.Nombres)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
            RuleFor(p => p.Paterno)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
        }
    }

}
