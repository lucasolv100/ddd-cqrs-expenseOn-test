﻿// <auto-generated />
using System;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel.Data.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel.Domain.Entites.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("DataCriacao");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("DataExclusao");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("EditDate")
                        .HasColumnName("DataEdicao");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnName("Comodidades")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(50);

                    b.Property<decimal>("Rating")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnName("Avaliacao")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Hoteis");
                });

            modelBuilder.Entity("Hotel.Domain.Entites.Hotel", b =>
                {
                    b.OwnsOne("Hotel.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("HotelId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasMaxLength(100);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("Numero")
                                .HasMaxLength(9);

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnName("Estado")
                                .HasMaxLength(50);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("Rua")
                                .HasMaxLength(50);

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("CEP")
                                .HasMaxLength(20);

                            b1.HasKey("HotelId");

                            b1.ToTable("Hoteis");

                            b1.HasOne("Hotel.Domain.Entites.Hotel")
                                .WithOne("Address")
                                .HasForeignKey("Hotel.Domain.ValueObjects.Address", "HotelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
