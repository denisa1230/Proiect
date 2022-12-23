﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect.Data;

#nullable disable

namespace Proiect.Migrations
{
    [DbContext(typeof(ProiectContext))]
    [Migration("20221223130044_Members")]
    partial class Members
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect.Models.Arrival", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ArrivalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Arrival");
                });

            modelBuilder.Entity("Proiect.Models.Bus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("ArrivalDates")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ArrivalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDates")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartureID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("ArrivalID");

                    b.HasIndex("DepartureID");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("Proiect.Models.BusCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BusID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BusID");

                    b.HasIndex("CategoryID");

                    b.ToTable("BusCategory");
                });

            modelBuilder.Entity("Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect.Models.Departure", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DepartureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Departure");
                });

            modelBuilder.Entity("Proiect.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Proiect.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BusID");

                    b.HasIndex("MemberID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Proiect.Models.Bus", b =>
                {
                    b.HasOne("Proiect.Models.Arrival", "Arrival")
                        .WithMany("Buses")
                        .HasForeignKey("ArrivalID");

                    b.HasOne("Proiect.Models.Departure", "Departure")
                        .WithMany("Buses")
                        .HasForeignKey("DepartureID");

                    b.Navigation("Arrival");

                    b.Navigation("Departure");
                });

            modelBuilder.Entity("Proiect.Models.BusCategory", b =>
                {
                    b.HasOne("Proiect.Models.Bus", "Bus")
                        .WithMany("BusCategories")
                        .HasForeignKey("BusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect.Models.Category", "Category")
                        .WithMany("BusCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Proiect.Models.Reservation", b =>
                {
                    b.HasOne("Proiect.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusID");

                    b.HasOne("Proiect.Models.Member", "Member")
                        .WithMany("Reservations")
                        .HasForeignKey("MemberID");

                    b.Navigation("Bus");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Proiect.Models.Arrival", b =>
                {
                    b.Navigation("Buses");
                });

            modelBuilder.Entity("Proiect.Models.Bus", b =>
                {
                    b.Navigation("BusCategories");
                });

            modelBuilder.Entity("Proiect.Models.Category", b =>
                {
                    b.Navigation("BusCategories");
                });

            modelBuilder.Entity("Proiect.Models.Departure", b =>
                {
                    b.Navigation("Buses");
                });

            modelBuilder.Entity("Proiect.Models.Member", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
