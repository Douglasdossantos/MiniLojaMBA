using MBA.Loja.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Data.Mappings
{
    public class VendedorMapping : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedores");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(v => v.Email)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(v => v.Telefone)
                .HasColumnType("nvarchar(20)");

            builder.Property(v => v.Documento)
                .HasColumnType("varchar(15)");

            builder.Property(v => v.TipoDocumento)
                .IsRequired();

            builder.Property(v => v.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(v => v.Ativo)
                .IsRequired();

            builder.HasMany(v => v.Produtos)
                .WithOne(p => p.Vendedor)
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
