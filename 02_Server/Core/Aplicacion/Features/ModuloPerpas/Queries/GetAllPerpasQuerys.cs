using Aplicacion.DTOs.ModuloPerpas;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Dominio.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.Features.ModuloPerpas.Queries
{


    public class GetAllPerpasQuery : IRequest<Response<List<PruebaPerpasDto>>>
    {
        public int? IdPersona { get; set; } // cambiar a int? para permitir valor nulo

        public class GetAllPerpasQueryHandler : IRequestHandler<GetAllPerpasQuery, Response<List<PruebaPerpasDto>>>
        {
            private readonly IRepositoryAsync<PruebaPerpas> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllPerpasQueryHandler(IRepositoryAsync<PruebaPerpas> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<PruebaPerpasDto>>> Handle(GetAllPerpasQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<PruebaPerpas> _Perpas;
                if (request.IdPersona.HasValue) // si tiene un valor
                {
                    _Perpas = await _repositoryAsync.ListAsync(new PerpasSpecification(request.IdPersona.Value), cancellationToken);
                }
                else // si no tiene un valor
                {
                    _Perpas = await _repositoryAsync.ListAsync(cancellationToken);
                }

                var _PerpasDto = _mapper.Map<List<PruebaPerpasDto>>(_Perpas);
                return new Response<List<PruebaPerpasDto>>(_PerpasDto);
            }
        }
    }


    public class PerpasSpecification : Specification<PruebaPerpas>
    {
        public PerpasSpecification(int IdPersona)
        {
            Query.Where(x => x.PersonaIdPersona == IdPersona ).Take(20);
        }
    }

    //public class GetAllPerpasQuery : IRequest<Response<List<PruebaPerpasDto>>>
    //

        //public class GetAllPerpasQueryHandler : IRequestHandler<GetAllPerpasQuery, Response<List<PruebaPerpasDto>>>
        //{
        //    private readonly IRepositoryAsync<PruebaPerpas> _repositoryAsync;
        //    private readonly IMapper _mapper;
        //    public GetAllPerpasQueryHandler(IRepositoryAsync<PruebaPerpas> repositoryAsync, IMapper mapper)
        //    {
        //        _repositoryAsync = repositoryAsync;
        //        _mapper = mapper;
        //    }

        //    public async Task<Response<List<PruebaPerpasDto>>> Handle(GetAllPerpasQuery request, CancellationToken cancellationToken)
        //    {
        //        var _Perpas = await _repositoryAsync.ListAsync();
        //        var _PerpasDto = _mapper.Map<List<PruebaPerpasDto>>(_Perpas);
        //        return new Response<List<PruebaPerpasDto>>(_PerpasDto);
        //    }
        //}

    //}

    //public class PerpasSpecification : Specification<EndtidadDominio>
    //{
    //    public FacturaSpecification(TipoParametro1 Parametro1, TipoParametro2 Parametro2)
    //    {
    //        Query.Where(x => x.Campo1 >= Parametro1 && x.campo2 <= Parametro2).Take(20);
    //    }
    //}
}
