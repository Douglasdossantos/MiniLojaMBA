using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Models.Validation;
using MBA.Loja.Business.Models;

namespace MBA.Loja.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }
            if (_produtoRepository.Buscar(f => f.Nome == produto.Nome).Result.Any())
            {
                Notificar("Já existe um Produto com esse nome informado");
                return;
            }

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }

            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
        public void Dispose()
        {
            _produtoRepository ?.Dispose();
        }
    }
}
