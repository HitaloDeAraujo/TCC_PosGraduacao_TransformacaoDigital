using Microsoft.EntityFrameworkCore;
using SIGO.GestaoNormas.Domain.Entities;
using SIGO.Infra;
using SIGO.Utils;

namespace SIGO.GestaoNormas.Infra.Mapping
{
    public class NormaMap : BaseMap<Norma>
    {
        public NormaMap(ModelBuilder modelBuilder) : base(modelBuilder)
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

            Map.Property(x => x.Titulo)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_MEDIUM);

            Map.Property(x => x.Descricao)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_LONG);

            Map.Property(x => x.RepositorioID)
                .HasColumnType(DataTypes.MySQL.INT)
                .IsRequired();
        }
    }
}