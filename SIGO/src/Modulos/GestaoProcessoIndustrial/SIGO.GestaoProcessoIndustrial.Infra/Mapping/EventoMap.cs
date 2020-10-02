using Microsoft.EntityFrameworkCore;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.Infra;
using SIGO.Utils;

namespace SIGO.GestaoProcessoIndustrial.Infra.Mapping
{
    public class EventoMap : BaseMap<Evento>
    {
        public EventoMap(ModelBuilder modelBuilder) : base(modelBuilder)
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
                .HasMaxLength(DataLength.TEXT_MEDIUM); ;

            Map.Property(x => x.Descricao)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_LONG);

            Map.Property(x => x.Grau)
                .HasColumnType(DataTypes.MySQL.INT)
                .IsRequired();

            Map.Property(x => x.TipoEventoID)
                .HasColumnType(DataTypes.MySQL.INT)
                .IsRequired();
        }
    }
}