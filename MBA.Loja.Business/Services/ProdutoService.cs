using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Models;
using MBA.Loja.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _ProdutoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador) 
        {
            _ProdutoRepository = produtoRepository;
        }

        public async Task Adicionr(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }

            await _ProdutoRepository.Adicionar(produto);    
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }

            await _ProdutoRepository.Atualizar(produto);    
        }

        public async Task Remover(Guid id)
        {
            await _ProdutoRepository.Remover(id);
        }
        public  void Dispose()
        {
            _ProdutoRepository?.Dispose();  
        }
    }
}
