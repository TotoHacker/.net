using ApplicationCore.Interfaces;
using Domain.Entities;
using Finbuckle.MultiTenant;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUserService currentUser)
        : base(currentTenant, options, currentUser)
    {

    }

    public DbSet<persona> persona { get; set; }
    public DbSet<logs> logs { get; set; }
    public DbSet<jugador> jugador { get; set; }
    public DbSet<Estudiantes> Estudiantes { get; set; }
    public DbSet<ColaboradoresEntities> Colaboradores { get; set; } // Agrega esta línea

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
