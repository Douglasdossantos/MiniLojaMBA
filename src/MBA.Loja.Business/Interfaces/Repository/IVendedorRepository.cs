using MBA.Loja.Business.Models;

namespace MBA.Loja.Business.Interfaces.Repository
{
    public interface IVendedorRepository : IRepository<Vendedor>
    {
        Task<Vendedor> ObterProdutodPorVendendor(Guid ProdutoId);
        Task<Categoria> ObterCategoriaVendedor(Guid VendedroId);
        Task<List<Vendedor>> ObterVendedoEId();
    }
}
