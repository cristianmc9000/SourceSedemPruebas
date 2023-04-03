using Aplicacion.DTOs;
//using Aplicacion.DTOs.Cliente;
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


    public class CreateEmpresaCommand : IRequest<Response<int>>
    {
        public PruebaEmpresaDto Empresa { get; set; }

    }

    public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PruebaEmpresa> _repositoryAsync;
        private readonly IMapper _mapper;
        public CreateEmpresaCommandHandler(IRepositoryAsync<PruebaEmpresa> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<PruebaEmpresa>(request.Empresa);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.IdEmpresa);
        }

        //Validador..
        public class CreateEmpresaCommandValidator : AbstractValidator<CreateEmpresaCommand>
        {
            public CreateEmpresaCommandValidator()
            {
                RuleFor(p => p.Empresa.Nombre)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                    .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
            }
        }
    }


}
