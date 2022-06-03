using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuariosService _usuariosService;

        public UsuarioController(IUsuariosService service)
        {
            _usuariosService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosService.Get());
        }

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

        [HttpGet]
        [Route("GetUsuariosConNotificacion")]
        public IActionResult GetUsuariosConNotificacion()
        {
            return Ok(_usuariosService.GetUsuariosConNotificacion());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _usuariosService.Save(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            _usuariosService.Update(id, usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _usuariosService.Delete(id);
            return Ok();
        }

    }
}