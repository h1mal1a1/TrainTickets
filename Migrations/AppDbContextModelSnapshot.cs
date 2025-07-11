﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TrainTickets;

#nullable disable

namespace TrainTickets.Migrations
{
    [DbContext(typeof(TrainTicketsDbContext.AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+BookingStatuses", b =>
                {
                    b.Property<int>("IdBookingStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdBookingStatus");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdBookingStatus"));

                    b.Property<string>("BookingName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("BookingName");

                    b.HasKey("IdBookingStatus");

                    b.HasIndex("BookingName")
                        .IsUnique();

                    b.HasIndex("IdBookingStatus");

                    b.ToTable("BookingStatuses", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+ClassTypes", b =>
                {
                    b.Property<int>("IdClassType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdClassType");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdClassType"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("TypeName");

                    b.HasKey("IdClassType");

                    b.HasIndex("IdClassType");

                    b.HasIndex("TypeName")
                        .IsUnique();

                    b.ToTable("ClassTypes", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+LastNames", b =>
                {
                    b.Property<int>("IdLastName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdLastName");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdLastName"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("LastName");

                    b.HasKey("IdLastName");

                    b.HasIndex("IdLastName");

                    b.HasIndex("LastName")
                        .IsUnique();

                    b.ToTable("LastNames", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Names", b =>
                {
                    b.Property<int>("IdName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdName");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdName"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdName");

                    b.HasIndex("IdName");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Names", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Patronymics", b =>
                {
                    b.Property<int>("IdPatronymic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdPatronymic");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPatronymic"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.HasKey("IdPatronymic");

                    b.HasIndex("IdPatronymic");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Patronymics", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Registration", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TicketId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TicketId"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ArrivalTime");

                    b.Property<int>("CarriageNumber")
                        .HasColumnType("integer")
                        .HasColumnName("CarriageNumber");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DateReg");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DepartureTime");

                    b.Property<int>("IdArrivalStation")
                        .HasColumnType("integer")
                        .HasColumnName("IdArrivalStation");

                    b.Property<int>("IdBookingStatus")
                        .HasColumnType("integer")
                        .HasColumnName("IdBookingStatus");

                    b.Property<int>("IdClassType")
                        .HasColumnType("integer")
                        .HasColumnName("IdClassType");

                    b.Property<int>("IdDepartureStation")
                        .HasColumnType("integer")
                        .HasColumnName("IdDepartureStation");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer")
                        .HasColumnName("IdUser");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("Price");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer")
                        .HasColumnName("SeatNumber");

                    b.Property<int>("TrainNumber")
                        .HasColumnType("integer")
                        .HasColumnName("TrainNumber");

                    b.HasKey("TicketId");

                    b.HasIndex("IdArrivalStation");

                    b.HasIndex("IdBookingStatus");

                    b.HasIndex("IdClassType");

                    b.HasIndex("IdDepartureStation");

                    b.HasIndex("IdUser");

                    b.ToTable("Registration", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Stations", b =>
                {
                    b.Property<int>("IdStation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("IdStation");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdStation"));

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("StationName");

                    b.HasKey("IdStation");

                    b.HasIndex("IdStation");

                    b.HasIndex("StationName")
                        .IsUnique();

                    b.ToTable("Stations", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DateRegistration");

                    b.Property<long>("INN")
                        .HasMaxLength(12)
                        .HasColumnType("bigint")
                        .HasColumnName("INN");

                    b.Property<int>("IdLastName")
                        .HasColumnType("integer")
                        .HasColumnName("IdLastName");

                    b.Property<int>("IdName")
                        .HasColumnType("integer")
                        .HasColumnName("IdName");

                    b.Property<int>("IdPatronymic")
                        .HasColumnType("integer")
                        .HasColumnName("IdPatronymics");

                    b.Property<int>("PassportNumber")
                        .HasMaxLength(6)
                        .HasColumnType("integer")
                        .HasColumnName("PassportNumber");

                    b.Property<int>("PassportSeries")
                        .HasMaxLength(4)
                        .HasColumnType("integer")
                        .HasColumnName("PassportSeries");

                    b.HasKey("UserId");

                    b.HasIndex("INN")
                        .IsUnique();

                    b.HasIndex("IdLastName");

                    b.HasIndex("IdName");

                    b.HasIndex("IdPatronymic");

                    b.HasIndex("PassportNumber")
                        .IsUnique();

                    b.HasIndex("PassportSeries")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Registration", b =>
                {
                    b.HasOne("TrainTickets.TrainTicketsDbContext+Stations", "ArrivalStation")
                        .WithMany("LstArrivals")
                        .HasForeignKey("IdArrivalStation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTickets.TrainTicketsDbContext+BookingStatuses", "BookingStatuse")
                        .WithMany("LstBookingStatuses")
                        .HasForeignKey("IdBookingStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTickets.TrainTicketsDbContext+ClassTypes", "ClassType")
                        .WithMany("LstClassTypes")
                        .HasForeignKey("IdClassType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTickets.TrainTicketsDbContext+Stations", "DepartureStation")
                        .WithMany("LstDepartures")
                        .HasForeignKey("IdDepartureStation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTickets.TrainTicketsDbContext+Users", "User")
                        .WithMany("LstUsers")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalStation");

                    b.Navigation("BookingStatuse");

                    b.Navigation("ClassType");

                    b.Navigation("DepartureStation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Users", b =>
                {
                    b.HasOne("TrainTickets.TrainTicketsDbContext+LastNames", "LastName")
                        .WithMany("LstLastNames")
                        .HasForeignKey("IdLastName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTickets.TrainTicketsDbContext+Names", "Name")
                        .WithMany("LstNames")
                        .HasForeignKey("IdName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainTickets.TrainTicketsDbContext+Patronymics", "Patronymic")
                        .WithMany("LstPatronymics")
                        .HasForeignKey("IdPatronymic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LastName");

                    b.Navigation("Name");

                    b.Navigation("Patronymic");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+BookingStatuses", b =>
                {
                    b.Navigation("LstBookingStatuses");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+ClassTypes", b =>
                {
                    b.Navigation("LstClassTypes");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+LastNames", b =>
                {
                    b.Navigation("LstLastNames");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Names", b =>
                {
                    b.Navigation("LstNames");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Patronymics", b =>
                {
                    b.Navigation("LstPatronymics");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Stations", b =>
                {
                    b.Navigation("LstArrivals");

                    b.Navigation("LstDepartures");
                });

            modelBuilder.Entity("TrainTickets.TrainTicketsDbContext+Users", b =>
                {
                    b.Navigation("LstUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
