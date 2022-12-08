using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class CategoriaController : ControllerBase
    {
        ICategoriasService categoriasService;

        public CategoriaController(ICategoriasService service)
        {
            categoriasService = service;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriasService.Get());
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{id}/{peso}")]
        public IActionResult Get(Guid id, int peso)
        {
            Categoria categoria = categoriasService.Get(id, peso); 
            
            if (categoria != null)
            {
                return Ok(categoria);
            }else{
                return NotFound();
            }
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        [Route("GetAllNames")]
        public IActionResult GetAllNames()
        {
            return Ok(categoriasService.GetAllNames());
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoriasService.Save(categoria);
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            categoriasService.Update(id, categoria);
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoriasService.Delete(id);
            return Ok();
        }
    }
}