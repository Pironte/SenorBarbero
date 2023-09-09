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
    public class ScheduleSlotController : ControllerBase
    {
        public ScheduleSlotService _scheduleSlotService;

        public ScheduleSlotController(ScheduleSlotService scheduleSlotService)
        {
            _scheduleSlotService = scheduleSlotService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ScheduleSlotDto scheduleSlotDto)
        {
            var schedule = _scheduleSlotService.Save(scheduleSlotDto);

            return CreatedAtAction(nameof(Get), new { id = schedule.Id }, schedule);
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult Get(int id)
        {
            var schedule = new ScheduleSlot();
            try
            {
                schedule = _scheduleSlotService.GetById(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ScheduleSlot> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _scheduleSlotService.GetAll().Skip(skip).Take(take);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, ScheduleSlotDto scheduleSlotDto)
        {
            try
            {
                var schedule = _scheduleSlotService.GetById(id);
                var success = _scheduleSlotService.Update(scheduleSlotDto, schedule);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdatePatch")]
        public IActionResult UpdatePatch(int id, JsonPatchDocument<ScheduleSlotDto> jsonPatchDocument)
        {
            try
            {
                var schedule = _scheduleSlotService.GetById(id);
                var scheduleToUpdate = _scheduleSlotService.GetPatchUpdateObject(schedule);

                jsonPatchDocument.ApplyTo(scheduleToUpdate, ModelState);
                if (!TryValidateModel(scheduleToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                var success = _scheduleSlotService.Update(scheduleToUpdate, schedule);
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
            var schedule = _scheduleSlotService.GetById(id);
            var success = _scheduleSlotService.Delete(schedule);
            return NoContent();
        }
    }
}
