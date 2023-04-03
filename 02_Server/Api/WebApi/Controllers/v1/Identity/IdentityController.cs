using Aplicacion.DTOs.Identity;
using Aplicacion.Features.Segurity.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Webapi.Controllers.v1.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseApiController
    {
        [HttpPost("autenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticatioRequest request)
        {
            return Ok(await Mediator.Send(new SegurityAuthenticateUserCommand
            {
                Usuario = request.UserName,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            }));
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        //{
        //    return Ok(await Mediator.Send(new RegisterUserCommand
        //    {
        //        Nombre = request.Nombre,
        //        Apellido = request.Apellido,               
        //        UserName = request.UserName,
        //        Password = request.Password,
        //        Origin = Request.Headers["origin"]
        //    }));
        //}

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Fowarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
