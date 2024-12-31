﻿// <auto-generated />
using System;
using FlashCards.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlashCards.Context.Migrations
{
    [DbContext(typeof(FlashCardsContext))]
    [Migration("20241231112240_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlashCards.Models.Deck", b =>
                {
                    b.Property<Guid>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeckName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeckId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("FlashCards.Models.FlashCard", b =>
                {
                    b.Property<Guid>("FlashCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DeckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EaseFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Interval")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastReviewed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlashCardId");

                    b.HasIndex("DeckId");

                    b.ToTable("FlashCards");
                });

            modelBuilder.Entity("FlashCards.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlashCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReviewId");

                    b.HasIndex("FlashCardId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FlashCards.Models.FlashCard", b =>
                {
                    b.HasOne("FlashCards.Models.Deck", null)
                        .WithMany("Flashcards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlashCards.Models.Review", b =>
                {
                    b.HasOne("FlashCards.Models.FlashCard", null)
                        .WithMany("Reviews")
                        .HasForeignKey("FlashCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlashCards.Models.Deck", b =>
                {
                    b.Navigation("Flashcards");
                });

            modelBuilder.Entity("FlashCards.Models.FlashCard", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
