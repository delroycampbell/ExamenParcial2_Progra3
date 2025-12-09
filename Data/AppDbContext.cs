using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenParcial2_Progra3.Models;

namespace ExamenParcial2_Progra3.Data
    {
    public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
            {
            }

        public DbSet<ExamenParcial2_Progra3.Models.CategoriaMeta> CategoriaMeta { get; set; } = default!;
        public DbSet<ExamenParcial2_Progra3.Models.EstadoMeta> EstadoMeta { get; set; } = default!;
        public DbSet<ExamenParcial2_Progra3.Models.Meta> Meta { get; set; } = default!;
        public DbSet<ExamenParcial2_Progra3.Models.PrioridadMeta> PrioridadMeta { get; set; } = default!;
        public DbSet<ExamenParcial2_Progra3.Models.Tarea> Tarea { get; set; } = default!;

        //Meta has many Tareas and one Tarea belongs to one Meta

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Meta>()
                .HasMany(m => m.Tareas)
                .WithOne(t => t.Meta)
                .HasForeignKey(t => t.MetaId)
                .OnDelete(DeleteBehavior.Cascade);
            }
        public DbSet<ExamenParcial2_Progra3.Models.EstadoTarea> EstadoTarea { get; set; } = default!;
        public DbSet<ExamenParcial2_Progra3.Models.Dificultad> Dificultad { get; set; } = default!;
        }
    }
