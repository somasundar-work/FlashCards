using FlashCards.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCards.Context.Configs
{
    internal class DeckBuilderConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.HasMany(x => x.Flashcards).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
