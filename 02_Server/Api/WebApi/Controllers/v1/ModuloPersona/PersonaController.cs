using Aplicacion.Features.ModuloPersona.Commands;
using Aplicacion.Features.ModuloPersona.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistencia.Contexts;
using System.Threading.Tasks;
using Webapi.Controllers.v1;
using AutoMapper;
using Aplicacion.DTOs.ModuloPersona;
using Dominio.Entities;
using System.Collections;
using System.Collections.Generic;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApi.Controllers.v1.ModuloPersona
{
	public class PersonaController : BaseApiController
	{
        private readonly IMapper _mapper;
        private readonly AplicationDbContext context;
        public PersonaController(AplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        //Método GET 1 - Método por defecto
        //[HttpGet()]
        //[Authorize] 
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await Mediator.Send(new GetAllPersonaQuery
        //    {
        //    }));
        //}

        //Método GET 2 - Usando Entity Framework Core Directamente
        [HttpGet()]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PruebaPersona>>> Get()
        {
            return await context.Persona.ToListAsync();
        }
        //ACABO DE SUBIR A GITHUB

        //Método GET 2 - Extensión de método 2, obtener un registro específico.
        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<PruebaPersona>> Get(int id)
        {
            var persona = await context.Persona
                .Include(p=> p.PruebaPerpas)
                    .ThenInclude(p => p.Pasatiempo)
                .FirstOrDefaultAsync(a => a.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        //Método GET 2 - Extensión de método 2, obteniendo registros que coincidan con la entrada.
        [HttpGet("nombre")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PruebaPersona>>> Get(string nombre)
        {
            //return await context.Persona.Where(a => a.Nombres == nombre).ToListAsync(); //Para retornar un dato específico.(ej. ID)
            return await context.Persona.Where(a => a.Nombres.Contains(nombre)).ToListAsync();
        }


        [HttpPost]
        [Authorize]
        //public async Task<IActionResult> Post(CreatePersonaCommand command)
        public async Task<IActionResult> Post(PruebaPersonaDto command)
        {

            //return Ok(await Mediator.Send(command)); //Enviar con Mediator a CreatePersonaCommand.cs

            // Validar la entrada //Recibiendo datos usando CreatePersonaCommand (que usa el DTO) y mapeando a la entidad PruebaPersona (2do método)
            //var validator = new CreatePersonaCommandValidator();
            //var validationResult = await validator.ValidateAsync(command);

            //if (!validationResult.IsValid)
            //{
            // Si hay errores de validación, devolver un BadRequest con los mensajes de error
            //return BadRequest(validationResult.Errors);
            //}

            // si la entrada es válida, mapear el DTO a una entidad de persona
            //var nuevaPersona = _mapper.Map<PruebaPersona>(command.persona);

            // Agregar la nueva persona y guardar los cambios en la base de datos
            //context.Add(nuevaPersona);
            //await context.SaveChangesAsync();

            // Devolver un Ok con la nueva persona agregada
            //return Ok(nuevaPersona);

            //3er Método - Recibiendo datos directamente, usando el DTO, validando en el DTO y mapeando a la entidad.
            var nuevaPersona = _mapper.Map<PruebaPersona>(command);
            context.Add(nuevaPersona);
            await context.SaveChangesAsync();
            return Ok(nuevaPersona);
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePersonaCommand command)
        {
            if (id != command.IdPersona)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonaCommand { IdPersona = id }));
        }
	}
}
