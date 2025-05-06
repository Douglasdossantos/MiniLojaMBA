using MBA.Loja.Business.Models;

namespace MBA.Loja.Business.Interfaces.Services
{
    public interface ICategoriaService : IDisposable
    {
        Task Adicionar(Categoria categoria);
        Task Atualizar(Categoria categoria);
        Task Remover(Guid id);
    }
}
