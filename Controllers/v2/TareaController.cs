using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class TareaController : ControllerBase
    {
        ITareasService tareaService;

        public TareaController(ITareasService service)
        {
            tareaService = service;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Tarea tarea = tareaService.Get(id);

            if(tarea != null){
                return Ok(tarea);
            }else{
                return NotFound();
            }
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        [Route("PorCategoria/{id}")]
        public IActionResult GetPorCategoria(Guid id)
        {
            List<Tarea> tareasPorCategoria = tareaService.GetPorCategoria(id);

            return Ok(tareasPorCategoria);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaService.Save(tarea);
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            tareaService.Update(id, tarea);
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareaService.Delete(id);
            return Ok();
        }
    }
}