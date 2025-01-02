using FlashCards.Application.Interfaces;
using FlashCards.Application.Specification;
using FlashCards.Application.Specification.Params;
using FlashCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.API.Controllers
{
    public class CardsController(IUnitOfWork unit) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCards([FromQuery] CardsSpecParams specParams)
        {
            var spec = new CardsSpecification(specParams);
            if (spec == null)
                return BadRequest("Invalid search criteria");
            return await CreatePagedResult(
                unit.Repository<Card>(),
                spec,
                specParams.PageIndex,
                specParams.PageSize
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard(Guid id)
        {
            if (unit.Repository<Card>().Exists(id))
                return Ok(await unit.Repository<Card>().GetByIdAsync(id));
            return NotFound("Card not found");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] Card Card)
        {
            unit.Repository<Card>().Add(Card);
            if (await unit.Complete())
            {
                return CreatedAtAction(nameof(GetCard), new { id = Card.Id }, Card);
            }
            return BadRequest("Failed to create Card");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(Guid id, Card Card)
        {
            if (id != Card.Id)
                return BadRequest("Card ID mismatch");

            if (!CardExists(id))
                return NotFound("Card not found");

            unit.Repository<Card>().Update(Card);

            if (await unit.Complete())
                return NoContent();

            return BadRequest("Failed to update Card");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCard(Guid id)
        {
            var Card = await unit.Repository<Card>().GetByIdAsync(id);
            if (Card == null)
                return NotFound("Card not found");
            unit.Repository<Card>().Delete(Card);
            if (await unit.Complete())
                return NoContent();
            return BadRequest("Failed to delete Card");
        }

        private bool CardExists(Guid id)
        {
            return unit.Repository<Card>().Exists(id);
        }
    }
}
