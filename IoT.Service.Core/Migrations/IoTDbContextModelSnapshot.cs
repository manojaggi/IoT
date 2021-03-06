﻿// <auto-generated />
using System;
using IoT.Service.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IoT.Service.Core.Migrations
{
    [DbContext(typeof(IoTDbContext))]
    partial class IoTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IoT.Core.Entity.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilterType");

                    b.Property<int>("FilterValue");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("IoT.Core.Entity.TelemetryData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DataValue");

                    b.Property<int>("DeviceConfigId");

                    b.Property<int?>("DeviceId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("TelemetryDatas");
                });

            modelBuilder.Entity("IoT.Core.Entity.TelemetryData", b =>
                {
                    b.HasOne("IoT.Core.Entity.Device")
                        .WithMany("TelemetryDatas")
                        .HasForeignKey("DeviceId");
                });
#pragma warning restore 612, 618
        }
    }
}
