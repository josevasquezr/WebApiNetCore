using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareasService tareaService;

        public TareaController(ITareasService service)
        {
            tareaService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }

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

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaService.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            tareaService.Update(id, tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareaService.Delete(id);
            return Ok();
        }
    }
}