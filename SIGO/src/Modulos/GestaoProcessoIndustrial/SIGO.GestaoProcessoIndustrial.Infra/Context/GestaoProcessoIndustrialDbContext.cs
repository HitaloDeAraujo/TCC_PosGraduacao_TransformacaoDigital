using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Infra.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Infra.Context
{
    public class GestaoProcessoIndustrialDbContext : DbContext
    {
        public GestaoProcessoIndustrialDbContext(DbContextOptions<GestaoProcessoIndustrialDbContext> options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<TipoEvento> TiposEvento { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            #region Mapeamento

            new EventoMap(modelBuilder);
            new TipoEventoMap(modelBuilder);
            new UsuarioMap(modelBuilder);

            #endregion

            modelBuilder.Entity<TipoEvento>().HasData(
              new TipoEvento
              {
                  ID = 1,
                  DataCriacao = DateTime.Now,
                  Nome = "Norma Cadastrada"
              },
              new TipoEvento
              {
                  ID = 2,
                  DataCriacao = DateTime.Now,
                  Nome = "Norma Atualizada"
              });

            modelBuilder.Entity<Evento>().HasData(
             new Evento
             {
                 ID = 1,
                 DataCriacao = DateTime.Now,
                 Nome = "Norma Cadastrada",
                 GUID = Guid.NewGuid(),
                 Descricao = "Desc",
                 Grau = 1,
                 TipoEventoID = 1
             });

            modelBuilder.Entity<Usuario>().HasData(
             new Usuario
             {
                 ID = 1,
                 DataCriacao = DateTime.Now,
                 GUID = Guid.NewGuid(),
                 Nome = "Hitalo",
                 Matricula = "123"
             });
        }

        public async Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;

                    if (entry.Entity.GetType().GetProperty("GUID") != null)
                        entry.Property("GUID").CurrentValue = Guid.NewGuid();
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;

                    entry.Property("DataModificacao").CurrentValue = DateTime.Now;

                    if (entry.Entity.GetType().GetProperty("GUID") != null)
                        entry.Property("GUID").IsModified = false;

                    if (entry.Property("DataExclusao").CurrentValue != null)
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
