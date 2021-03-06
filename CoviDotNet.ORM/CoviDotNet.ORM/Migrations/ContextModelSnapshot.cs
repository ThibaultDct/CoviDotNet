﻿// <auto-generated />
using System;
using CoviDotNet.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoviDotNet.ORM.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CoviDotNet.ORM.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsResident")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CoviDotNet.ORM.Vaccination", b =>
                {
                    b.Property<int>("VaccinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lot")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReminderDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VaccinationDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VaccineId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VaccinationId");

                    b.HasIndex("PersonId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("CoviDotNet.ORM.Vaccine", b =>
                {
                    b.Property<int>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Disease")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ValidityPeriod")
                        .HasColumnType("INTEGER");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("CoviDotNet.ORM.Vaccination", b =>
                {
                    b.HasOne("CoviDotNet.ORM.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("CoviDotNet.ORM.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId");

                    b.Navigation("Person");

                    b.Navigation("Vaccine");
                });
#pragma warning restore 612, 618
        }
    }
}
