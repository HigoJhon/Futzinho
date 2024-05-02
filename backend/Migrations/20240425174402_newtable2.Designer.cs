﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Context;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(BrasContext))]
    [Migration("20240425174402_newtable2")]
    partial class newtable2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Championship", b =>
                {
                    b.Property<int>("ChampionshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChampionshipId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Prize")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("QunaityTeams")
                        .HasColumnType("int");

                    b.HasKey("ChampionshipId");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("backend.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Midfield")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("backend.Models.TeamChampionshipLink", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("ChampionshipId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "ChampionshipId");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("TeamChampionshipLinks");
                });

            modelBuilder.Entity("backend.Models.TeamChampionshipLink", b =>
                {
                    b.HasOne("backend.Models.Championship", "Championship")
                        .WithMany("TeamChampionshipLinks")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Team", "Team")
                        .WithMany("TeamChampionshipLinks")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("backend.Models.Championship", b =>
                {
                    b.Navigation("TeamChampionshipLinks");
                });

            modelBuilder.Entity("backend.Models.Team", b =>
                {
                    b.Navigation("TeamChampionshipLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
