using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Services;
using MBA.Loja.Data.Context;
using MBA.Loja.Data.Repository;

namespace MBA.Loja.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecias(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoiaService, CategoriaService>();
            services.AddScoped<IVendedorService, VendedorService>();

            return services;
        }
    }
}
