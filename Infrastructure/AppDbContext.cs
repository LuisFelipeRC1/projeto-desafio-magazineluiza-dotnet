using Microsoft.EntityFrameworkCore;
using NodaTime;
using DesafioMagazineLuiza.Domain;

namespace DesafioMagazineLuiza.Infrastructure;

public class AppDbContext : DbContext
{
   
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments => Set<Appointment>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<Appointment>();

        entity.HasKey(a => a.Id);

        entity.Property(a => a.Text)
            .IsRequired()
            .HasMaxLength(500);

        entity.Property(a => a.Recipient)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(a => a.ChannelType)
            .HasConversion<string>()
            .IsRequired();

        entity.Property(a => a.Status)
            .HasConversion<string>()
            .IsRequired();

        entity.Property(a => a.CreatedAt)
            .HasConversion(
                v => v.ToDateTimeUnspecified(),
                v => LocalDateTime.FromDateTime(v)
            )
            .IsRequired();

        entity.Property(a => a.Date)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
