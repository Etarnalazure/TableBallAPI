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
    [Migration("20230922063435_TryingToForceAdditionOfWinnerGuid")]
    partial class TryingToForceAdditionOfWinnerGuid
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

                    b.Property<Guid>("PlayerOneGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerTwoGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WinnerGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

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
