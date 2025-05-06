using AutoMapper;
using MBA.Loja.App.ViewModels;
using MBA.Loja.App.ViewModels.Categoria;
using MBA.Loja.App.ViewModels.Vendedor;
using MBA.Loja.Business.Models;

namespace MBA.Loja.App.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(s => s.NomeVendedor, t => t.MapFrom(s => s.Vendedor.Nome))
                .ForMember(a => a.NomeCategoria, g => g.MapFrom(a => a.Categoria.Nome));

            CreateMap<VendedorComboBoxViewModel,  Vendedor>().ReverseMap();
            CreateMap<VendedorViewModel, Vendedor>().ReverseMap();

            CreateMap<CreateProdutoViewModel, Produto>().ReverseMap();
            CreateMap<CategoriaComboBoxViewModel, Categoria>().ReverseMap();  
            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();

        }
    }
}
