using MBA.Loja.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBA.Loja.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("nvarchar(300)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Estoque)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.Property(p => p.Imagem)
                .HasColumnType("varchar(500)");

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);

            builder.HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
