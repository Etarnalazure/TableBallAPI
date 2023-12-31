﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableBallAPI.DatabaseContext;

#nullable disable

namespace TableBallAPI.Migrations
{
    [DbContext(typeof(TableBallContext))]
    [Migration("20230922060056_WinnerIDColumnAdd")]
    partial class WinnerIDColumnAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TableBallAPI.Models.BattleBaseModel", b =>
                {
                    b.Property<Guid>("UniqueBattleGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BattleDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlayerOneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerTwoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UniqueBattleGuid");

                    b.ToTable("Battle", (string)null);
                });

            modelBuilder.Entity("TableBallAPI.Models.PlayerBaseModel", b =>
                {
                    b.Property<Guid>("UniquePlayerGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Handicap")
                        .HasColumnType("int");

                    b.Property<string>("PlayerInitials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniquePlayerGuid");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("TableBallAPI.Models.TeamBaseModel", b =>
                {
                    b.Property<Guid>("UniqueTeamGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamScore")
                        .HasColumnType("int");

                    b.HasKey("UniqueTeamGuid");

                    b.ToTable("Team", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
