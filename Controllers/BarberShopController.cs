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
    public class BarberShopController : ControllerBase
    {
        public BarberShopService _barberShopService;

        public BarberShopController(BarberShopService barberShopService)
        {
            _barberShopService = barberShopService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(BarberShopDto barberShopDto)
        {
            var barberShop = _barberShopService.Save(barberShopDto);

            return CreatedAtAction(nameof(Get), new { id = barberShop.Id }, barberShop);
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult Get(int id)
        {
            var barberShop = new BarberShop();
            try
            {
                barberShop = _barberShopService.GetById(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return Ok(barberShop);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<BarberShop> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _barberShopService.GetAll().Skip(skip).Take(take);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, BarberShopDto barberShopDto)
        {
            try
            {
                var barberShop = _barberShopService.GetById(id);
                var success = _barberShopService.Update(barberShopDto, barberShop);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdatePatch")]
        public IActionResult UpdatePatch(int id, JsonPatchDocument<BarberShopDto> jsonPatchDocument)
        {
            try
            {
                var barberShop = _barberShopService.GetById(id);
                var barberShopToUpdate = _barberShopService.GetPatchUpdateObject(barberShop);

                jsonPatchDocument.ApplyTo(barberShopToUpdate, ModelState);
                if (!TryValidateModel(barberShopToUpdate))
                {
                    return ValidationProblem(ModelState);
                }

                var success = _barberShopService.Update(barberShopToUpdate, barberShop);
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
            var barberShop = _barberShopService.GetById(id);
            var success = _barberShopService.Delete(barberShop);
            return NoContent();
        }
    }
}
