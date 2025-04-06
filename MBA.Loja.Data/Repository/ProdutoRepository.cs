using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Models;
using MBA.Loja.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MBA.Loja.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyDbContext db) : base(db) {}

        public async Task<Produto> ObterProdudoEVendedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                            .Include(v => v.Vendedor)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public  async Task<IEnumerable<Produto>> ObterProdutoPorCategoria(Guid id)
        {
            return Db.Produtos.AsNoTracking()
                .Include(c => c.Categoria)
                .Where(x => x.CategoriaId == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorVendendor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(v => v.Vendedor)
                .Where(p => p.VendedorId == id)
                .ToListAsync();
        }
    }
}
