using Aplicacion.Features.Sucursal.Commands;
using Aplicacion.Features.Sucursal.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.Sucursal
{
    [ApiVersion("1.0")]
    [Authorize]
    public class FcSucursalController : BaseApiController
    {

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllSucursalQuery
            {
                
            }));
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateSucursalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSucursalCommand { IdSucursal = id }));
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateSucursalCommand command)
        {
            if (id != command.IdfcSucursal)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
