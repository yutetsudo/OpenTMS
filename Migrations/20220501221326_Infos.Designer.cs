﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenTMS.Data;

#nullable disable

namespace OpenTMS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220501221326_Infos")]
    partial class Infos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("OpenTMS.Info", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("Token");

                    b.ToTable("Infos");
                });
#pragma warning restore 612, 618
        }
    }
}