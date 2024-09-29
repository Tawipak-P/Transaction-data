﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transaction.Infrastructor;

#nullable disable

namespace Transaction.Infrastructor.Migrations.TransactionDb
{
    [DbContext(typeof(TransactionDbContext))]
    [Migration("20240929080808_UpdateDateCoulmn")]
    partial class UpdateDateCoulmn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Transaction.Infrastructor.Entities.TD_CurrencyCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("TD_CurrencyCodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyCode = "USD"
                        },
                        new
                        {
                            Id = 2,
                            CurrencyCode = "EUR"
                        },
                        new
                        {
                            Id = 3,
                            CurrencyCode = "JPY"
                        },
                        new
                        {
                            Id = 4,
                            CurrencyCode = "GBP"
                        },
                        new
                        {
                            Id = 5,
                            CurrencyCode = "AUD"
                        },
                        new
                        {
                            Id = 6,
                            CurrencyCode = "CAD"
                        },
                        new
                        {
                            Id = 7,
                            CurrencyCode = "CHF"
                        },
                        new
                        {
                            Id = 8,
                            CurrencyCode = "CNY"
                        },
                        new
                        {
                            Id = 9,
                            CurrencyCode = "SEK"
                        },
                        new
                        {
                            Id = 10,
                            CurrencyCode = "NZD"
                        });
                });

            modelBuilder.Entity("Transaction.Infrastructor.Entities.TD_Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TD_Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Approved",
                            Prefix = "A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rejected",
                            Prefix = "R"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Done",
                            Prefix = "D"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Failed",
                            Prefix = "R"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Finished",
                            Prefix = "D"
                        });
                });

            modelBuilder.Entity("Transaction.Infrastructor.Entities.TD_Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountNo")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.ToTable("TD_Transactions");
                });

            modelBuilder.Entity("Transaction.Infrastructor.StoreProcedures.TransactionDataResults", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TransactionDataResults");
                });
#pragma warning restore 612, 618
        }
    }
}
