﻿// <auto-generated />
using GeekHunter.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeekHunter.Migrations
{
    [DbContext(typeof(GeekHunterContext))]
    [Migration("20181217092955_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("GeekHunter.Model.Candidate", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("GeekHunter.Model.Skill", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });
#pragma warning restore 612, 618
        }
    }
}