using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Notificacoes;
using MBA.Loja.Business.Services;
using MBA.Loja.Data.Context;
using MBA.Loja.Data.Repository;

namespace MBA.Loja.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendedorService, VendedorService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
