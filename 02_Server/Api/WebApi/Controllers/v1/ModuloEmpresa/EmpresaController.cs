using Aplicacion.Features.ModuloEmpresa.Commands;
using Aplicacion.Features.ModuloEmpresa.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;

namespace WebApi.Controllers.v1.ModuloEmpresa
{
    public class EmpresaController : BaseApiController
    {


        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllEmpresaQuery
            {

            }));
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateEmpresaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateEmpresaCommand command)
        {
            if (id != command.IdEmpresa)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteEmpresaCommand { IdEmpresa = id }));
        }
    }
}
