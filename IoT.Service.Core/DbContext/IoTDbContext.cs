using IoT.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoT.Service.Core
{
    public class IoTDbContext: DbContext
    {
        public virtual DbSet<TelemetryData> TelemetryDatas { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public IoTDbContext(DbContextOptions<IoTDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelemetryData>(entity =>
            {
                entity.Property(e => e.Id);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id);
            });
        }
    }
}
