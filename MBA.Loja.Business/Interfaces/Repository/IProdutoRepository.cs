using MBA.Loja.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Interfaces.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorVendendor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutoPorCategoria(Guid id);
        Task<Produto> ObterProdudoEVendedor(Guid id);
    }
}
