﻿// <auto-generated />
using System;
using GameStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GameStoreAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220205122733_GameStore_Genre")]
    partial class GameStore_Genre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GameStoreAPI.Models.Genre", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameStoreGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("GenreName")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.HasIndex("GameStoreGuid");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Web_API.GameStore", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Guid");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameStoreAPI.Models.Genre", b =>
                {
                    b.HasOne("Web_API.GameStore", "gameStore")
                        .WithMany("ListGenre")
                        .HasForeignKey("GameStoreGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gameStore");
                });

            modelBuilder.Entity("Web_API.GameStore", b =>
                {
                    b.Navigation("ListGenre");
                });
#pragma warning restore 612, 618
        }
    }
}