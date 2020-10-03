using Microsoft.EntityFrameworkCore;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.Infra;
using SIGO.Utils;

namespace SIGO.GestaoProcessoIndustrial.Infra.Mapping
{
    public class UsuarioMap : BaseMap<Usuario>
    {
        public UsuarioMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Map.Property(x => x.GUID)
                .ValueGeneratedOnAdd();

            Map.Property(x => x.GUID)
                .HasColumnType(DataTypes.MySQL.GUID)
                .IsRequired()
                .HasMaxLength(DataLength.GUID);

            Map.Property(x => x.Nome)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_MEDIUM);

            Map.Property(x => x.Matricula)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_SHORT);
        }
    }
}
