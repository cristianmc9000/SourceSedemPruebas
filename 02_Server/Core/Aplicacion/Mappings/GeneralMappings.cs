
using Aplicacion.DTOs.Cliente;
using Aplicacion.DTOs.ModuloPersona;
using Aplicacion.DTOs.ModuloEmpresa;
using Aplicacion.DTOs.ModuloPasatiempo;
using Aplicacion.DTOs.ModuloPerpas;
using Aplicacion.DTOs.Segurity;
using Aplicacion.DTOs.Sucursal;
using AutoMapper;
using Dominio.Entities;
using Dominio.Entities.Seguridad;

//using Aplicacion.DTOs.ModuloPerPas;

namespace Aplicacion.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            //TODO: Agregar aqui el registro de mapeo para obtenion de consultas  direccion  EntidadDominio --> ModeloDto
            #region QueryDto
            CreateMap<SegvUsuario, SegUsuarioDto>();
            CreateMap<FcCliente, FcClienteDto>();
            CreateMap<FcSucursal, FcSucursalDto>();
            /**///**
            /*PRUEBA PERSONA*/
            CreateMap<PruebaPersona, PruebaPersonaDto>();
            /*Prueba Empresa*/
            CreateMap<PruebaEmpresa, PruebaEmpresaDto>();
            /*pasatiempos*/
            CreateMap<PruebaPasatiempo, PruebaPasatiempoDto>();
            CreateMap<PruebaPerpas, PruebaPerpasDto>();
            #endregion

            //TODO: Agregar aqui el registro de mapeo para ejecucion de comandos  direccion  ModeloDto --> EntidadDominio Ej. : CreateMap<ProductoDto, CapProducto>();
            #region Commands
            CreateMap<FcClienteDto, FcCliente>();
            CreateMap<FcSucursalDto, FcSucursal>();

            /*prueba persona*/
            CreateMap<PruebaPersonaDto, PruebaPersona>();
            /*Prueba Empresa*/
            CreateMap<PruebaEmpresaDto, PruebaEmpresa>();
            /*pasatiempos*/
            CreateMap<PruebaPasatiempoDto, PruebaPasatiempo>();
            CreateMap<PruebaPerpasDto, PruebaPerpas>();
            #endregion

        }
    }
}
