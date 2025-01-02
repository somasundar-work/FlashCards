using System;
using FlashCards.Application.Specification.Params;
using FlashCards.Models;

namespace FlashCards.Application.Specification;

public class DecksSpecification : BaseSpecification<Deck>
{
    public DecksSpecification(DecksSpecParams specParams)
        : base(x =>
            (
                string.IsNullOrEmpty(specParams.Search)
                || x.DeckName.ToLower().Contains(specParams.Search)
            )
        )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
    }
}
