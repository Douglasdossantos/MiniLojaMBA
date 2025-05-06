using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Models;
using MBA.Loja.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MBA.Loja.Data.Repository
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(MyDbContext db) : base(db) { }

        public async Task<Categoria> ObterCategoriaVendedor(Guid VendedroId)
        {
            return await Db.Produtos.AsNoTracking()
                .Where(p => p.VendedorId == VendedroId)
                .Include(p => p.Categoria)
                .Select(p => p.Categoria)
                .FirstOrDefaultAsync();
        }

        public async Task<Vendedor> ObterProdutodPorVendendor(Guid ProdutoId)
        {
            return await Db.Vendedores.AsNoTracking()
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(p => p.Id == ProdutoId);
        }

        public async Task<List<Vendedor>> ObterVendedoEId()
        {
            return await Db.Vendedores
                .AsNoTracking()
                .ToListAsync();
        }
    }
}