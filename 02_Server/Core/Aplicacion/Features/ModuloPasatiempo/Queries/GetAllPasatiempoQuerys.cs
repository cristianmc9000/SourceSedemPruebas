using Aplicacion.DTOs.ModuloPasatiempo;
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


namespace Aplicacion.Features.ModuloPasatiempo.Queries
{

    public class GetAllPasatiempoQuery : IRequest<Response<List<PruebaPasatiempoDto>>>
    {

        public class GetAllPasatiempoQueryHandler : IRequestHandler<GetAllPasatiempoQuery, Response<List<PruebaPasatiempoDto>>>
        {
            private readonly IRepositoryAsync<PruebaPasatiempo> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllPasatiempoQueryHandler(IRepositoryAsync<PruebaPasatiempo> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<PruebaPasatiempoDto>>> Handle(GetAllPasatiempoQuery request, CancellationToken cancellationToken)
            {
                var _Pasatiempo = await _repositoryAsync.ListAsync();
                var _PasatiempoDto = _mapper.Map<List<PruebaPasatiempoDto>>(_Pasatiempo);
                return new Response<List<PruebaPasatiempoDto>>(_PasatiempoDto);
            }
        }

    }

    //public class PerPasSpecification : Specification<EndtidadDominio>
    //{
    //    public FacturaSpecification(TipoParametro1 Parametro1, TipoParametro2 Parametro2)
    //    {
    //        Query.Where(x => x.Campo1 >= Parametro1 && x.campo2 <= Parametro2).Take(20);
    //    }
    //}
}
