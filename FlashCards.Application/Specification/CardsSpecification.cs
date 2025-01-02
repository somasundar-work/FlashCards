using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCards.Application.Specification;
using FlashCards.Application.Specification.Params;
using FlashCards.Models;

namespace FlashCards.Application.Specification
{
    public class CardsSpecification : BaseSpecification<Card>
    {
        public CardsSpecification(CardsSpecParams specParams)
            : base(x =>
                (
                    (
                        specParams.DeckId == null
                        || specParams.DeckId == Guid.Empty
                        || x.DeckId == specParams.DeckId
                    )
                    || (
                        string.IsNullOrEmpty(specParams.Search)
                        || x.Question.ToLower().Contains(specParams.Search)
                        || x.Answer.ToLower().Contains(specParams.Search)
                    )
                )
            )
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }
    }
}
