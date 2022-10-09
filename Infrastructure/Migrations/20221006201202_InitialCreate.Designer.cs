﻿// <auto-generated />
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221006201202_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Actual", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Household")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Population")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Actuals");
                });

            modelBuilder.Entity("Domain.Estimate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Household")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Population")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Estimates");
                });
#pragma warning restore 612, 618
        }
    }
}
