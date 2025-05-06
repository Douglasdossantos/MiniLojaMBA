using MBA.Loja.App.Data;
using MBA.Loja.Business.Enums;
using MBA.Loja.Business.Models;
using MBA.Loja.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MBA.Loja.App.Configurations
{
    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            var IdentityContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (env.IsDevelopment())
            {
                await context.Database.MigrateAsync();
                await IdentityContext.Database.MigrateAsync();

                await EnsureSeedProducts(context, IdentityContext);

            }
        }
        private static async Task EnsureSeedProducts(MyDbContext myDbContext, ApplicationDbContext applicationDbContext)
        {
            try
            {
                if (!myDbContext.Categorias.Any())
                {
                    var categoria = new Categoria
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Categoria A"
                    };

                    await myDbContext.Categorias.AddAsync(categoria);

                    if (!myDbContext.Vendedores.Any())
                    {
                        var vendedorA = new Vendedor
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Vendedor A",
                            Email = "vendedor_a@teste.com.br",
                            DataCadastro = DateTime.Now.AddYears(-34),
                            Ativo = true,
                            Documento = "99999999999",
                            TipoDocumento = EnumDocumento.CPF,
                            Telefone = "(44)999999999"
                        };

                        var vendedorB = new Vendedor
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Vendedor B",
                            Email = "vendedor_b@teste.com.br",
                            DataCadastro = DateTime.Now.AddYears(-34),
                            Ativo = true,
                            Documento = "88888888888",
                            TipoDocumento = EnumDocumento.CPF,
                            Telefone = "(44)999999999"
                        };

                        await myDbContext.Vendedores.AddRangeAsync(vendedorA, vendedorB);

                        if (!myDbContext.Produtos.Any())
                        {
                            var produtos = new List<Produto>{
                                new Produto
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = "Produto A",
                                    Descricao = "Descricao do produto a",
                                    Ativo = true,
                                    Imagem = "sem imagem",
                                    CategoriaId = categoria.Id,
                                    DataCadastro = DateTime.Now.AddDays(-100),
                                    Estoque = 23,
                                    Preco = 12.22m,
                                    VendedorId = vendedorA.Id
                                },
                                new Produto
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = "Produto B",
                                    Descricao = "Descricao do produto b",
                                    Ativo = true,
                                    Imagem = "sem imagem",
                                    CategoriaId = categoria.Id,
                                    DataCadastro = DateTime.Now.AddDays(-90),
                                    Estoque = 23,
                                    Preco = 12.20m,
                                    VendedorId = vendedorB.Id
                                },
                                new Produto
                                {
                                    Id = Guid.NewGuid(),
                                    Nome = "Produto C",
                                    Descricao = "Descricao do produto c",
                                    Ativo = true,
                                    Imagem = "sem imagem",
                                    CategoriaId = categoria.Id,
                                    DataCadastro = DateTime.Now.AddDays(-40),
                                    Estoque = 23,
                                    Preco = 12.20m,
                                    VendedorId = vendedorB.Id
                                }
                            };

                            await myDbContext.Produtos.AddRangeAsync(produtos);
                        }
                    }
                    await myDbContext.SaveChangesAsync();
                }

                if (!applicationDbContext.Users.Any())
                {
                    var user = new IdentityUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "Test@teste.com",
                        NormalizedUserName = "TEST@TESTE.COM",
                        Email = "teste@teste.com",
                        NormalizedEmail = "TESTE@TESTE.COM",
                        AccessFailedCount = 0,
                        LockoutEnabled = false,
                        PasswordHash = "AQAAAAIAAYagAAAAEKB1ERT/XI87AYyXECc88aqLho3XYnf0+MGc8vewb6Km3UGGrUSlXRv56VcTJoGWXg==",
                        TwoFactorEnabled = false,
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    await applicationDbContext.Users.AddAsync(user);
                    await applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar seed:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }
}
