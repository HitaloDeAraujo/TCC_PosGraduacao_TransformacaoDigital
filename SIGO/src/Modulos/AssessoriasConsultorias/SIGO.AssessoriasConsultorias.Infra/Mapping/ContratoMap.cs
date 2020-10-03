using Microsoft.EntityFrameworkCore;
using SIGO.AssessoriasConsultorias.Domain.Entities;
using SIGO.Infra;
using SIGO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.AssessoriasConsultorias.Infra.Mapping
{
    public class ContratoMap : BaseMap<Contrato>
    {
        public ContratoMap(ModelBuilder modelBuilder) : base(modelBuilder)
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

            Map.Property(x => x.Descricao)
                .HasColumnType(DataTypes.MySQL.STRING)
                .IsRequired()
                .HasMaxLength(DataLength.TEXT_LONG);

            Map.Property(x => x.URL)
               .HasColumnType(DataTypes.MySQL.STRING)
               .IsRequired();

            Map.Property(x => x.ParceiroID)
                .HasColumnType(DataTypes.MySQL.INT)
                .IsRequired();
        }
    }
}
