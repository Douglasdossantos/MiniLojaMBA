using AutoMapper;
using MBA.Loja.Api.ViewModel;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository; 
        private readonly IProdutoService _produtoService;   
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IProdutoService produtoService, 
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return Ok(produtoViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id, ProdutoViewModel produtoViewModel)
        {
            return Ok();
        }
        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }
    }
}
