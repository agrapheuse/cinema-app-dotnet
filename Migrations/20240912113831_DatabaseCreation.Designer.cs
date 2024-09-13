﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace cinemaApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240912113831_DatabaseCreation")]
    partial class DatabaseCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Models.Movie", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("uuid");

                    b.Property<string>("Category")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("category");

                    b.Property<string>("Cinema")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cinema");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_time");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Director")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("director");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("InfoLink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("info_link");

                    b.Property<string>("TicketLink")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ticket_link");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Uuid");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
