using MBA.Loja.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MBA.Loja.Data.Mapping
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
                .HasColumnType("varchar(200)");

            builder.Property(v => v.Telefone)
                .HasColumnType("varchar(20)");

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
