using FlashCards.Application.Interfaces;
using FlashCards.Application.Service;
using FlashCards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.API.Controllers
{
    public class ReviewsController(IUnitOfWork unit, ReviewService service) : BaseApiController
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateReview(Guid id, [FromBody] RatingStatus status)
        {
            Card? card = await unit.Repository<Card>().GetByIdAsync(id);
            if (card == null)
                return BadRequest("card not found");

            service.GetReview(card, status);
            unit.Repository<Card>().Update(card);
            if (await unit.Complete())
                return NoContent();

            return BadRequest("update review failed");
        }
    }
}
