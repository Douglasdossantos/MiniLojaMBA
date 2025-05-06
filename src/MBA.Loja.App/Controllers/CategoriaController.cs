using AutoMapper;
using MBA.Loja.App.ViewModels.Categoria;
using MBA.Loja.App.ViewModels.Vendedor;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MBA.Loja.App.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());

            return View(Categorias);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();  
        }

    }
}
