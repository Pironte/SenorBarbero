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
    public class ScheduleController : ControllerBase
    {
        public ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ScheduleDto scheduleDto)
        {
            var schedule = _scheduleService.Save(scheduleDto);

            return CreatedAtAction(nameof(Get), new { id = schedule.Id }, schedule);
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult Get(int id)
        {
            var schedule = new Schedule();
            try
            {
                schedule = _scheduleService.GetById(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Schedule> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _scheduleService.GetAll().Skip(skip).Take(take);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, ScheduleDto scheduleDto)
        {
            try
            {
                var schedule = _scheduleService.GetById(id);
                var success = _scheduleService.Update(scheduleDto, schedule);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdatePatch")]
        public IActionResult UpdatePatch(int id, JsonPatchDocument<ScheduleDto> jsonPatchDocument)
        {
            try
            {
                var schedule = _scheduleService.GetById(id);
                var scheduleToUpdate = _scheduleService.GetPatchUpdateObject(schedule);

                jsonPatchDocument.ApplyTo(scheduleToUpdate, ModelState);
                if (!TryValidateModel(scheduleToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                var success = _scheduleService.Update(scheduleToUpdate, schedule);
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
            var schedule = _scheduleService.GetById(id);
            var success = _scheduleService.Delete(schedule);
            return NoContent();
        }
    }
}
