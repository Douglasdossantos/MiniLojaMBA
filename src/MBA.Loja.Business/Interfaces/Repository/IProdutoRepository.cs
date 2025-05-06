using MBA.Loja.Business.Models;

namespace MBA.Loja.Business.Interfaces.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorVendendor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutoPorCategoria(Guid id);
        Task<Produto> ObterProdudoEVendedor(Guid id);
    }
}
