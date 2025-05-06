using AutoMapper;
using MBA.Loja.Api.ViewModels;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Models;
using MBA.Loja.Business.Notificacoes;
using MBA.Loja.Business.Services;
using MBA.Loja.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class VendedorController : MainController
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IVendedorService _vendedorService;
        private readonly IMapper _mapper;

        public VendedorController(IVendedorRepository vendedorRepository, IVendedorService vendedorService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _vendedorRepository = vendedorRepository;
            _vendedorService = vendedorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VendedorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VendedorViewModel>>(await _vendedorRepository.ObterTodos());
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VendedorViewModel>> ObterPorId(Guid id)
        {
            var vendedor = await ObterVendedor(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return Ok(vendedor);
        }

        [HttpPost]
        public async Task<ActionResult<AddVendedorViewModel>> Adicionar(AddVendedorViewModel vendedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            await _vendedorRepository.Adicionar(_mapper.Map<Vendedor>(vendedorViewModel));

            return CustomResponse(HttpStatusCode.Created, vendedorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AtualizarVendedorViewModel>> Atualizar(Guid id, AtualizarVendedorViewModel vendedorViewModel)
        {
            if (id != vendedorViewModel.Id)
            {
                NotificarErro("O id Informado não corresponde ao mesmo informado");
                return CustomResponse();
            }
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _vendedorRepository.Atualizar(_mapper.Map<Vendedor>(vendedorViewModel));

            return CustomResponse(HttpStatusCode.NoContent, vendedorViewModel.Id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var produto = await ObterVendedor(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _vendedorService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<VendedorViewModel> ObterVendedor(Guid id)
        {
            return _mapper.Map<VendedorViewModel>(await _vendedorRepository.ObterPorId(id));
        }
    }
}
