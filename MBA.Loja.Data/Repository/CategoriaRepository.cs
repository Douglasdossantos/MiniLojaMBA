using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Models;
using MBA.Loja.Data.Context;

namespace MBA.Loja.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MyDbContext db) : base(db)
        {
        }
    }
}
