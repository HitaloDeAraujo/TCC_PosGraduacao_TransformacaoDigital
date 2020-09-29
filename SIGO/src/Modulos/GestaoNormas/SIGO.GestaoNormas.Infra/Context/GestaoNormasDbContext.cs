using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIGO.GestaoNormas.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Infra.Context
{
    public class GestaoNormasDbContext : DbContext
    {
        private IConfiguration _configuration;

        public GestaoNormasDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region DbSet

        public DbSet<Norma> Normas { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DoctorCnnSqlServer"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            #region Mapeamento

            //new RepositorioMap(modelBuilder);

            #endregion
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
