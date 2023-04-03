using Aplicacion.Features.ModuloPerpas.Commands;
using Aplicacion.Features.ModuloPerpas.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.ModuloPerpas
{
    public class PerpasController : BaseApiController
    {

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllPerpasQuery()));
        }


        [HttpGet("{idPersona}")]
        [Authorize]
        public async Task<IActionResult> Get(int idPersona)
        {
            return Ok(await Mediator.Send(new GetAllPerpasQuery { IdPersona = idPersona }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePerpasCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        //[HttpPut("{id}")]
        //[Authorize]
        //public async Task<IActionResult> Put(int id, UpdatePerpasCommand command)
        //{
        //    if (id != command.IdPersona)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePerpasCommand { IdPersona = id }));
        }
    }
}
