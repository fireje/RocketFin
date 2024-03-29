﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RocketFin.Api.Persistance.Context;

#nullable disable

namespace RocketFin.Api.Migrations
{
    [DbContext(typeof(RocketFinDbContext))]
    [Migration("20240113141742_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("RocketFin.Api.Persistance.Model.LedgerDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfShares")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionTimeStampUTC")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ledgers");
                });
#pragma warning restore 612, 618
        }
    }
}
