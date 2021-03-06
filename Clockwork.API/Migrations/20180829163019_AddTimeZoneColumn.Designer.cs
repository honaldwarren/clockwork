﻿// <auto-generated />
using System;
using Clockwork.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clockwork.API.Migrations
{
    [DbContext(typeof(ClockworkContext))]
    [Migration("20180829163019_AddTimeZoneColumn")]
    partial class AddTimeZoneColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("Clockwork.API.Models.CurrentTimeQuery", b =>
                {
                    b.Property<int>("CurrentTimeQueryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientIp");

                    b.Property<DateTime>("Time");

                    b.Property<string>("TimeZone");

                    b.Property<DateTime>("UTCTime");

                    b.HasKey("CurrentTimeQueryId");

                    b.ToTable("CurrentTimeQueries");
                });
#pragma warning restore 612, 618
        }
    }
}
