using AutoMapper;
using MBA.Loja.Api.ViewModel;
using MBA.Loja.Business.Models;

namespace MBA.Loja.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel,Produto>(); 
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(cat => cat.NomeCategoria, ve => ve.MapFrom(vend => vend.Vendedor.Nome));
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Vendedor, VendedorViewModel>().ReverseMap();
        }
    }
}
