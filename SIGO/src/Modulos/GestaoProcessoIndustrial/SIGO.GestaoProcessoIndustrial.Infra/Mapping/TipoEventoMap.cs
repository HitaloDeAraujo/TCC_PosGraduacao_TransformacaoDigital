using Microsoft.EntityFrameworkCore;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.Infra;
using SIGO.Utils;

namespace SIGO.GestaoProcessoIndustrial.Infra.Mapping
{
    public class TipoEventoMap : BaseMap<TipoEvento>
    {
        public TipoEventoMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Map.Property(x => x.Nome)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_MEDIUM);
        }
    }
}