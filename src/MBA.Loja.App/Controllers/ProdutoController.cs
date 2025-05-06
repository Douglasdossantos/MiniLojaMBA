using AutoMapper;
using MBA.Loja.App.Models;
using MBA.Loja.App.ViewModels;
using MBA.Loja.App.ViewModels.Categoria;
using MBA.Loja.App.ViewModels.Vendedor;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Produto = MBA.Loja.Business.Models.Produto;

namespace MBA.Loja.App.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, 
            IProdutoService produtoService, 
            IMapper mapper, 
            ICategoriaRepository categoriaRepository,
            IVendedorRepository vendedorRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
            _vendedorRepository = vendedorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return View(produtos);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var categorias = _mapper.Map<IEnumerable<CategoriaComboBoxViewModel>>(await _categoriaRepository.ObterTodos());
            var vendedores = _mapper.Map<IEnumerable<VendedorComboBoxViewModel>>(await _vendedorRepository.ObterTodos());

            var view = new CreateProdutoViewModel
            {
                Categorias = categorias.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }),
                Vendedores = vendedores.Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = v.Nome
                })
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,ImagemUpload,Valor,VendedorId,Descricao,Preco,Estoque, CategoriaId")] CreateProdutoViewModel produtoViewMode)
        {
            if (ModelState.IsValid)
            {
                var imgPrefixo = Guid.NewGuid()+"_";
                if (!await UplaodArquivo(produtoViewMode.ImagemUpload,imgPrefixo))
                {
                    return View(produtoViewMode);
                }

                var produto = new Produto()
                {
                    Nome = produtoViewMode.Nome,
                    Descricao = produtoViewMode.Descricao,
                    Preco = (decimal)produtoViewMode.Preco,
                    Estoque = produtoViewMode.Estoque,
                    Imagem = imgPrefixo + produtoViewMode.ImagemUpload.FileName,
                    DataCadastro = DateTime.Now,
                    Ativo = produtoViewMode.Ativo,
                    VendedorId = produtoViewMode.VendedorId,
                    CategoriaId = produtoViewMode.CategoriaId
                };

               await _produtoService.Adicionar(produto);

                return RedirectToAction("Index");   

            }
            return View("Create",produtoViewMode);
        }

        private  async Task<bool> UplaodArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <=0 )
            {
                return false;
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images", imgPrefixo+arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já Existe um arquivo com esse nome!");
                return false;
            }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }
            return true;
        }
    }
}
