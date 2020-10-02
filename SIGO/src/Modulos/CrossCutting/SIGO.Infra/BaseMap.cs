using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Domain.Entities;
using SIGO.Utils;

namespace SIGO.Infra
{
    public abstract class BaseMap<T> where T : EntidadeBase
    {
        protected EntityTypeBuilder<T> Map;

        protected BaseMap(ModelBuilder modelBuilder)
        {
            Map = modelBuilder.Entity<T>();

            Map.HasKey(x => x.ID);

            Map.Property(x => x.ID)
               .ValueGeneratedOnAdd();

            Map.Property(x => x.ID)
               .HasColumnType(DataTypes.MySQL.INT)
               .IsRequired();

            Map.Property(x => x.DataCriacao)
               .HasColumnType(DataTypes.MySQL.DATETIME)
               .IsRequired();

            Map.Property(x => x.DataExclusao)
               .HasColumnType(DataTypes.MySQL.DATETIME)
               .IsRequired(false);
        }
    }
}