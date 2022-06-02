using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        ICategoriasService categoriasService;

        public CategoriaController(ICategoriasService service)
        {
            categoriasService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriasService.Get());
        }

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

        [HttpGet]
        [Route("GetAllNames")]
        public IActionResult GetAllNames()
        {
            return Ok(categoriasService.GetAllNames());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoriasService.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            categoriasService.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoriasService.Delete(id);
            return Ok();
        }
    }
}