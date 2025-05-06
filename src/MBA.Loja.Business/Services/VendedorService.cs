using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Models.Validation;
using MBA.Loja.Business.Models;

namespace MBA.Loja.Business.Services
{
    public class VendedorService : BaseService, IVendedorService
    {
        private readonly IVendedorRepository _VendedorRepository;
        private readonly IProdutoRepository _ProdutoRepository;

        public VendedorService(IVendedorRepository VendedorRepository, IProdutoRepository ProdutoRepository, INotificador notificador) : base(notificador)
        {
            _VendedorRepository = VendedorRepository;
            _ProdutoRepository = ProdutoRepository;
        }
        public async Task Adicionar(Vendedor vendedor)
        {
            if (!ExecutarValidacao(new VendendorValidation(), vendedor))
            {
                return;
            }

            if (_VendedorRepository.Buscar(f => f.Documento == vendedor.Documento).Result.Any())
            {
                Notificar("já existe um Vendedor com esse Documento informado!");
                return;
            }
            await _VendedorRepository.Adicionar(vendedor);
        }

        public async Task AdicionarProduto(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }
            await _ProdutoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Vendedor vendedor)
        {
            if (!ExecutarValidacao(new VendendorValidation(), vendedor))
            {
                return;
            }

            if (_VendedorRepository.Buscar(f => f.Documento == vendedor.Documento && f.Id != vendedor.Id).Result.Any()) ;
            {
                Notificar("já existe um Vendedor com esse Documento informado!");
                return;
            }
            await _VendedorRepository.Atualizar(vendedor);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }

            await _ProdutoRepository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            var vendedor = await _VendedorRepository.ObterPorId(id);
            if (vendedor == null)
            {
                Notificar("Vendedor não encontrado!");
                return;
            }
            var produtosVendedor = await _VendedorRepository.ObterProdutodPorVendendor(id);

            if (vendedor.Produtos != null && vendedor.Produtos.Any())
            {
                Notificar("O vendedor possui produtos vinculado a ele, por isso a sua remoção será bloqueada");
                return;
            }

            await _VendedorRepository.Remover(id);
        }

        public async Task RemoverProduto(Guid id)
        {
            await _ProdutoRepository.Remover(id);
        }
        public void Dispose()
        {
            _ProdutoRepository?.Dispose();
            _VendedorRepository?.Dispose();
        }
    }
}
