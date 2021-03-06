// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebovaAplikace.Data;

#nullable disable

namespace WebovaAplikace.Migrations
{
    [DbContext(typeof(NasDatovyKontext))]
    [Migration("20220314104359_VytvoreniDatabazeOdNuly")]
    partial class VytvoreniDatabazeOdNuly
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebovaAplikace.Models.Poznamka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CasPridani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nadpis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Poznamky");
                });

            modelBuilder.Entity("WebovaAplikace.Models.Pristup", b =>
                {
                    b.Property<string>("Heslo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Heslo");

                    b.ToTable("Pristup");
                });
#pragma warning restore 612, 618
        }
    }
}
