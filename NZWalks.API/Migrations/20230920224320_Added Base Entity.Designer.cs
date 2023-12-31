﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20230920224320_Added Base Entity")]
    partial class AddedBaseEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(922),
                            IsDeleted = false,
                            Name = "Easy",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(923)
                        },
                        new
                        {
                            Id = new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(947),
                            IsDeleted = false,
                            Name = "Medium",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(947)
                        },
                        new
                        {
                            Id = new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(949),
                            IsDeleted = false,
                            Name = "Hard",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(950)
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b082d575-2826-4277-91f5-d300ddcf3438"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1023),
                            Code = "AKL",
                            IsDeleted = false,
                            Name = "AuckLand",
                            RegionImageUrl = "https://test.com/image1.png",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1024)
                        },
                        new
                        {
                            Id = new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1030),
                            Code = "NTL",
                            IsDeleted = false,
                            Name = "NorthLand",
                            RegionImageUrl = "https://test.com/image2.png",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1030)
                        },
                        new
                        {
                            Id = new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1033),
                            Code = "BOP",
                            IsDeleted = false,
                            Name = "Bay of Plenty",
                            RegionImageUrl = "https://test.com/image3.png",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1033)
                        },
                        new
                        {
                            Id = new Guid("51440791-8a91-4e61-8f6d-602860252f93"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1036),
                            Code = "WGN",
                            IsDeleted = false,
                            Name = "Wellington",
                            RegionImageUrl = "https://test.com/image4.png",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1036)
                        },
                        new
                        {
                            Id = new Guid("390b81b6-0879-481a-8720-42f5b8637c41"),
                            AddedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1038),
                            Code = "NSN",
                            IsDeleted = false,
                            Name = "Nelson",
                            RegionImageUrl = "https://test.com/image5.png",
                            Status = 0,
                            UpdatedDate = new DateTime(2023, 9, 20, 22, 43, 20, 712, DateTimeKind.Utc).AddTicks(1038)
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
