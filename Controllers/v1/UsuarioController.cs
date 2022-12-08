using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UsuarioController : ControllerBase
    {
        private IUsuariosService _usuariosService;

        public UsuarioController(IUsuariosService service)
        {
            _usuariosService = service;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosService.Get());
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Usuario usuario = _usuariosService.Get(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }else{
                return NotFound();
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("GetUsuariosConNotificacion")]
        public IActionResult GetUsuariosConNotificacion()
        {
            return Ok(_usuariosService.GetUsuariosConNotificacion());
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _usuariosService.Save(usuario);
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            _usuariosService.Update(id, usuario);
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _usuariosService.Delete(id);
            return Ok();
        }

    }
}