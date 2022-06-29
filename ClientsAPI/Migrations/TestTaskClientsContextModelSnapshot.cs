﻿// <auto-generated />
using System;
using ClientsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientsAPI.Migrations
{
    [DbContext(typeof(TestTaskClientsContext))]
    partial class TestTaskClientsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChildClient", b =>
                {
                    b.Property<Guid>("ChildrenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChildrenId", "ParentsId");

                    b.HasIndex("ParentsId");

                    b.ToTable("ChildClient");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("House")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CurWorkExp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LivingAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("MonExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MonIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PassportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RegAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeEducation")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LivingAddressId");

                    b.HasIndex("PassportId");

                    b.HasIndex("RegAddressId");

                    b.ToTable("Clients");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Client");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Communication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Communications");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDismissal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEmp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FactAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JurAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("MonIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FactAddressId");

                    b.HasIndex("JurAddressId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Passport", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<string>("Giver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.ClientWithSpouse", b =>
                {
                    b.HasBaseType("ClientsAPI.Data.Entities.Client");

                    b.Property<Guid?>("SpouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("SpouseId");

                    b.HasDiscriminator().HasValue("ClientWithSpouse");
                });

            modelBuilder.Entity("ChildClient", b =>
                {
                    b.HasOne("ClientsAPI.Data.Entities.Child", null)
                        .WithMany()
                        .HasForeignKey("ChildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientsAPI.Data.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ParentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Client", b =>
                {
                    b.HasOne("ClientsAPI.Data.Entities.Address", "LivingAddress")
                        .WithMany()
                        .HasForeignKey("LivingAddressId");

                    b.HasOne("ClientsAPI.Data.Entities.Passport", "Passport")
                        .WithMany()
                        .HasForeignKey("PassportId");

                    b.HasOne("ClientsAPI.Data.Entities.Address", "RegAddress")
                        .WithMany()
                        .HasForeignKey("RegAddressId");

                    b.Navigation("LivingAddress");

                    b.Navigation("Passport");

                    b.Navigation("RegAddress");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Communication", b =>
                {
                    b.HasOne("ClientsAPI.Data.Entities.Client", null)
                        .WithMany("Communications")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Document", b =>
                {
                    b.HasOne("ClientsAPI.Data.Entities.Client", null)
                        .WithMany("DocumentIds")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Job", b =>
                {
                    b.HasOne("ClientsAPI.Data.Entities.Client", null)
                        .WithMany("Jobs")
                        .HasForeignKey("ClientId");

                    b.HasOne("ClientsAPI.Data.Entities.Address", "FactAddress")
                        .WithMany()
                        .HasForeignKey("FactAddressId");

                    b.HasOne("ClientsAPI.Data.Entities.Address", "JurAddress")
                        .WithMany()
                        .HasForeignKey("JurAddressId");

                    b.Navigation("FactAddress");

                    b.Navigation("JurAddress");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.ClientWithSpouse", b =>
                {
                    b.HasOne("ClientsAPI.Data.Entities.Client", "Spouse")
                        .WithMany()
                        .HasForeignKey("SpouseId");

                    b.Navigation("Spouse");
                });

            modelBuilder.Entity("ClientsAPI.Data.Entities.Client", b =>
                {
                    b.Navigation("Communications");

                    b.Navigation("DocumentIds");

                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
