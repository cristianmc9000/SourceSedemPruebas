using Aplicacion.DTOs.ModuloPersona;
using Aplicacion.Features.ModuloPerpas.Queries;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Dominio.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.Features.ModuloPersona.Queries
{
	public class GetAllPersonaQuery : IRequest<Response<List<PruebaPersonaDto>>>
	{

	public class GetAllPersonaQueryHandler : IRequestHandler<GetAllPersonaQuery, Response<List<PruebaPersonaDto>>>
		{
			private readonly IRepositoryAsync<PruebaPersona> _repositoryAsync;
			private readonly IMapper _mapper;

			public GetAllPersonaQueryHandler(IRepositoryAsync<PruebaPersona> repositoryAsync, IMapper mapper)
			{
				_repositoryAsync = repositoryAsync;
				_mapper = mapper;
			}

			public async Task<Response<List<PruebaPersonaDto>>> Handle(GetAllPersonaQuery request, CancellationToken cancellationToken)
			{
                //var _Persona = await _repositoryAsync.ListAsync(new PersonaSpecification(), cancellationToken);
                var _Persona = await _repositoryAsync.ListAsync();
                var _PersonaDto = _mapper.Map<List<PruebaPersonaDto>>(_Persona);
				return new Response<List<PruebaPersonaDto>>(_PersonaDto);
			}
		}
	}
   // public class PersonaSpecification : Specification<PruebaPersona>
   // {
   //     public PersonaSpecification()
   //     {
			//Query.Include(x => x.PruebaPerpas)
			//	.ThenInclude(ab => ab.Pasatiempo);
   //     }
   // }
}
