using Microsoft.EntityFrameworkCore;
using SIGO.AssessoriasConsultorias.Domain.Entities;
using SIGO.Infra;
using SIGO.Utils;

namespace SIGO.AssessoriasConsultorias.Infra.Mapping
{
    public class ParceiroMap : BaseMap<Parceiro>
    {
        public ParceiroMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Map.Property(x => x.GUID)
                .ValueGeneratedOnAdd();

            Map.Property(x => x.GUID)
                .HasColumnType(DataTypes.MySQL.GUID)
                .IsRequired()
                .HasMaxLength(DataLength.GUID);

            Map.Property(x => x.Tipo)
                .HasColumnType(DataTypes.MySQL.SHORT)
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
