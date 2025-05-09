﻿using MBA.Loja.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MBA.Loja.Data.Mapping
{
    namespace MBA.Loja.Data.Mappings
    {
        public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
        {
            public void Configure(EntityTypeBuilder<Categoria> builder)
            {
                builder.ToTable("Categorias");

                builder.HasKey(c => c.Id);

                builder.Property(c => c.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                builder.Property(c => c.Ativo)
                    .IsRequired();

                builder.HasMany(c => c.Produtos)
                    .WithOne(p => p.Categoria)
                    .HasForeignKey(p => p.CategoriaId);
            }
        }
    }
}
