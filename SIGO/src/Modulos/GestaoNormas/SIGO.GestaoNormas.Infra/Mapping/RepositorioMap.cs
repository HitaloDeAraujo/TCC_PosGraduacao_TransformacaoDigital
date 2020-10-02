using Microsoft.EntityFrameworkCore;
using SIGO.GestaoNormas.Domain.Entities;
using SIGO.Utils;

namespace SIGO.GestaoNormas.Infra.Mapping
{
    public class RepositorioMap : BaseMap<Repositorio>
    {
        public RepositorioMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Map.Property(x => x.GUID)
                .ValueGeneratedOnAdd();

            Map.Property(x => x.GUID)
                .HasColumnType(DataTypes.MySQL.GUID)
                .IsRequired()
                .HasMaxLength(DataLength.GUID);

            Map.Property(x => x.URL)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired();

            Map.Property(x => x.Nome)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_MEDIUM);

            Map.Property(x => x.Descricao)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_LONG);
        }
    }
}