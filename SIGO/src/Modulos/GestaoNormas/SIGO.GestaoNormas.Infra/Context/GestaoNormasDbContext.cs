using Microsoft.EntityFrameworkCore;
using SIGO.GestaoNormas.Domain.Entities;
using SIGO.GestaoNormas.Infra.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Infra.Context
{
    public class GestaoNormasDbContext : DbContext
    {
        public GestaoNormasDbContext(DbContextOptions<GestaoNormasDbContext> options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Norma> Normas { get; set; }
        public DbSet<Repositorio> Repositorios { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            #region Mapeamento

            new NormaMap(modelBuilder);
            new RepositorioMap(modelBuilder);

            #endregion

            modelBuilder.Entity<Repositorio>().HasData(
               new Repositorio
               {
                   ID = 1,
                   DataCriacao = DateTime.Now,
                   GUID = Guid.NewGuid(),
                   URL = "https://github.com/HitaloDeAraujo",
                   Nome = "Hitalo de Araujo",
                   Descricao = "Repositório de Hitalo de Araujo"
               });

            modelBuilder.Entity<Norma>().HasData(
                new Norma
                {
                    ID = 1,
                    DataCriacao = DateTime.Now,
                    GUID = Guid.NewGuid(),
                    URL = "https://github.com/HitaloDeAraujo/AgenteConversacao/blob/master/HITALO%20ARAUJO%20PROJETO%20E%20DESENVOLVIMENTO%20DE%20UM%20ARCABOU%C3%87O%20DE%20AGENTE%20DE%20CONVERSA%C3%87%C3%83O%20-%2011.pdf",
                    Titulo = "Norma de Criação de Agentes de Conversação",
                    Descricao = "Norma de Criação de Agentes de Conversação criada por Hitalo de Araujo",
                    RepositorioID = 1
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
