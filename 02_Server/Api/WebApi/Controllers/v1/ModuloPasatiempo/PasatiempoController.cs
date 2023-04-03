//using Aplicacion.Features.ModuloPasatiempo.Commands;
using Aplicacion.Features.ModuloPasatiempo.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapi.Controllers.v1;


namespace WebApi.Controllers.v1.ModuloPasatiempo
{
    public class PasatiempoController : BaseApiController
    {

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllPasatiempoQuery
            {

            }));
        }
    }
}
