using Microsoft.EntityFrameworkCore;
using SIGO.AssessoriasConsultorias.Domain.Entities;
using SIGO.AssessoriasConsultorias.Domain.Enums;
using SIGO.AssessoriasConsultorias.Infra.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Infra.Context
{
    public class AssessoriasConsultoriasDbContext : DbContext
    {
        public AssessoriasConsultoriasDbContext(DbContextOptions<AssessoriasConsultoriasDbContext> options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Parceiro> Parceiros{ get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            #region Mapeamento

            new ContratoMap(modelBuilder);
            new ParceiroMap(modelBuilder);

            #endregion

            modelBuilder.Entity<Parceiro>().HasData(
               new Parceiro
               {
                   ID = 1,
                   DataCriacao = DateTime.Now,
                   GUID = Guid.NewGuid(),
                   Nome = "Contrato 1",
                   Descricao = "Descrição 1",
                   Tipo = TipoParceiro.Assessoria
               });

            modelBuilder.Entity<Contrato>().HasData(
               new Contrato
               {
                   ID = 1,
                   DataCriacao = DateTime.Now,
                   GUID = Guid.NewGuid(),
                   Nome = "Contrato 1",
                   Descricao = "Descrição 1",
                   URL = "URL",
                   ParceiroID = 1
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
