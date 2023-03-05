using ComputerConfigurator.Models.Citilink;
using ComputerConfigurator.Models.NotDetail;
using Microsoft.EntityFrameworkCore;
using ComputerConfigurator.Models;

namespace ComputerConfigurator.Storage
{
    public class AutoDataContext : DbContext
    {
        public AutoDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SocketModel> Sockets { get; set; }
        public DbSet<MotherboardFormFactor> FormFactors { get; set; }

        public DbSet<ConfigurationCitilink> Configurations { get; set; }

        public DbSet<CpuCitilink> Processors { get; set; }
        public DbSet<GpuCitilink> GraphicCards { get; set; }
        public DbSet<MotherboardCitilink> Motherboards { get; set; }
        public DbSet<HddCitilink> HardDisks { get; set; }
        public DbSet<SsdCitilink> SsdDisks { get; set; }
        public DbSet<CasingCitilink> Casings { get; set; }
        public DbSet<RamCitilink> Ram { get; set; }
        public DbSet<PsuCitilink> Psu { get; set; }
        public DbSet<AudiocardCitilink> Audiocards { get; set; }
        public DbSet<CoolerCitilink> Coolers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CoolerCitilink>()
                .HasMany(c => c.SocketSupport)
                .WithMany(s => s.CoolerSupport)
                .UsingEntity<SocketCooler>(
                j => j
                .HasOne(pt => pt.Socket)
                .WithMany(t => t.SocketCoolers)
                .HasForeignKey(pt => pt.IdSocket),
                j => j
                .HasOne(pt => pt.Cooler)
                .WithMany(t => t.SocketCoolers)
                .HasForeignKey(pt => pt.IdCooler),
                j =>
                {
                    j.HasKey(t => new { t.IdSocket, t.IdCooler });
                    j.ToTable("SocketCooler");
                });

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");


            modelBuilder
                .Entity<AudiocardCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");
            
            modelBuilder
                .Entity<CasingCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<CoolerCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<CpuCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<GpuCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<HddCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<MotherboardCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<PsuCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<RamCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<SsdCitilink>()
                .Property(t => t.LastAccessTime)
                .HasDefaultValueSql("sysdate(3)");

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Processor)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.ProcessorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Audiocard)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.AudiocardId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Casing)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.CasingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Cooler)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.CoolerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.GraphicCard)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.GraphicCardId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Hdd)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.HddId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Motherboard)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.MotherboardId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Psu)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.PsuId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Ram)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.RamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .HasOne(e => e.Ssd)
                .WithMany(e => e.Configurations)
                .HasForeignKey(e => e.SsdId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.MotherboardId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.AudiocardId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.CasingId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.CoolerId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.ProcessorId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.GraphicCardId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.HddId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.PsuId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.RamId)
                .IsRequired(false);
            modelBuilder
                .Entity<ConfigurationCitilink>()
                .Property(e => e.SsdId)
                .IsRequired(false);
        }
    }
}
