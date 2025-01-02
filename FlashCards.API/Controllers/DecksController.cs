using FlashCards.API.RequestHelpers;
using FlashCards.Application.Interfaces;
using FlashCards.Application.Specification;
using FlashCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.API.Controllers
{
    public class DecksController(IUnitOfWork unit) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetDecks([FromQuery] DecksSpecParams specParams)
        {
            var spec = new DecksSpecification(specParams);
            if (spec == null)
                return BadRequest("Invalid search criteria");
            return Ok(
                await CreatePagedResult(
                    unit.Repository<Deck>(),
                    spec,
                    specParams.PageIndex,
                    specParams.PageSize
                )
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeck(Guid id)
        {
            if (unit.Repository<Deck>().Exists(id))
                return Ok(await unit.Repository<Deck>().GetByIdAsync(id));
            return NotFound("Deck not found");
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeck([FromBody] Deck deck)
        {
            unit.Repository<Deck>().Add(deck);
            if (await unit.Complete())
            {
                return CreatedAtAction(nameof(GetDeck), new { id = deck.Id }, deck);
            }
            return BadRequest("Failed to create deck");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeck(Guid id, Deck deck)
        {
            if (id != deck.Id)
                return BadRequest("Deck ID mismatch");

            if (!DeckExists(id))
                return NotFound("Deck not found");

            unit.Repository<Deck>().Update(deck);

            if (await unit.Complete())
                return NoContent();

            return BadRequest("Failed to update deck");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeck(Guid id)
        {
            var deck = await unit.Repository<Deck>().GetByIdAsync(id);
            if (deck == null)
                return NotFound("Deck not found");
            unit.Repository<Deck>().Delete(deck);
            if (await unit.Complete())
                return NoContent();
            return BadRequest("Failed to delete deck");
        }

        private bool DeckExists(Guid id)
        {
            return unit.Repository<Deck>().Exists(id);
        }
    }
}
