using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoriaController : ControllerBase
    {
        ICategoriasService categoriasService;

        public CategoriaController(ICategoriasService service)
        {
            categoriasService = service;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriasService.Get());
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Categoria categoria = categoriasService.Get(id); 
            
            if (categoria != null)
            {
                return Ok(categoria);
            }else{
                return NotFound();
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("GetAllNames")]
        public IActionResult GetAllNames()
        {
            return Ok(categoriasService.GetAllNames());
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoriasService.Save(categoria);
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            categoriasService.Update(id, categoria);
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoriasService.Delete(id);
            return Ok();
        }
    }
}