﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using szamonkeres_01._04.Models;

#nullable disable

namespace szamonkeres_01._04.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20240104084729_elso")]
    partial class elso
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("szamonkeres_01._04.Models.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("szamonkeres_01._04.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Born")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("szamonkeres_01._04.Models.CreditCard", b =>
                {
                    b.HasOne("szamonkeres_01._04.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
