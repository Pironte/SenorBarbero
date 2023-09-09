using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SenorBarbero.Data.Dtos;
using SenorBarbero.Model;
using SenorBarbero.Services;

namespace SenorBarbero.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        public ServiceService _service;

        public ServiceController(ServiceService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ServiceDto serviceDto)
        {
            var service = _service.Save(serviceDto);

            return CreatedAtAction(nameof(Get), new { id = service.Id }, service);
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult Get(int id)
        {
            var service = new Service();
            try
            {
                service = _service.GetById(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Service> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _service.GetAll().Skip(skip).Take(take);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, ServiceDto serviceDto)
        {
            try
            {
                var service = _service.GetById(id);
                var success = _service.Update(serviceDto, service);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdatePatch")]
        public IActionResult UpdatePatch(int id, JsonPatchDocument<ServiceDto> jsonPatchDocument)
        {
            try
            {
                var service = _service.GetById(id);
                var serviceToUpdate = _service.GetPatchUpdateObject(service);

                jsonPatchDocument.ApplyTo(serviceToUpdate, ModelState);
                if (!TryValidateModel(serviceToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                var success = _service.Update(serviceToUpdate, service);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var service = _service.GetById(id);
            var success = _service.Delete(service);
            return NoContent();
        }
    }
}
