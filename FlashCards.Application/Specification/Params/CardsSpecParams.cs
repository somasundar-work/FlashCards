﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Application.Specification.Params
{
    public class CardsSpecParams : PagingParams
    {
        public Guid? DeckId { get; set; }
    }
}
