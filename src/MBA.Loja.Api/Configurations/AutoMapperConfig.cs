using AutoMapper;
using MBA.Loja.Api.ViewModels;
using MBA.Loja.Business.Models;

namespace MBA.Loja.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(s => s.NomeVendedor, t => t.MapFrom(s => s.Vendedor.Nome))
                .ForMember(a => a.NomeCategoria, g => g.MapFrom(a => a.Categoria.Nome));

            CreateMap<CategoriaComProdutosViewModel, Categoria>().ReverseMap();
            CreateMap<AddCategoriaViewModel, Categoria>().ReverseMap();
            CreateMap<AtualizarCategoriaViewModel, Categoria>().ReverseMap();

            CreateMap<VendedorViewModel, Vendedor>().ReverseMap();
            CreateMap<AddVendedorViewModel, Vendedor>().ReverseMap();
            CreateMap<AtualizarVendedorViewModel, Vendedor>().ReverseMap();
        }
    }
}
