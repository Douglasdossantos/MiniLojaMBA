using AutoMapper;
using MBA.Loja.App.ViewModels.Vendedor;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MBA.Loja.App.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IMapper _mapper;

        public VendedorController(IVendedorRepository vendedorRepository, IMapper mapper)
        {
            _vendedorRepository = vendedorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var vendedores = _mapper.Map<IEnumerable<VendedorViewModel>>(await _vendedorRepository.ObterTodos());
            return View(vendedores);
        }
    }
}
