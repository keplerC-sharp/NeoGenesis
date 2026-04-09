using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class NeoGenesisContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var host = Environment.GetEnvironmentVariable("DB_HOST");
        // Console.WriteLine(host);
        var database = Environment.GetEnvironmentVariable("DB_NAME");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        if (string.IsNullOrEmpty(host) ||
            string.IsNullOrEmpty(database) ||
            string.IsNullOrEmpty(user) ||
            string.IsNullOrEmpty(password))
        {
            throw new Exception("Faltan variables de entorno para la conexión a la base de datos.");
        }

        var connectionString = $"server={host};database={database};user={user};password={password}";

        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dinosaur>(entity =>
        {
            entity.Property(d => d.FirstName).IsRequired();
            entity.Property(d => d.LastName).IsRequired();
            entity.Property(d => d.Username).IsRequired();
            entity.Property(d => d.Email).IsRequired();

            // MySQL usa CURRENT_TIMESTAMP
            entity.Property(d => d.CreationDate)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}