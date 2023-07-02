using Microsoft.EntityFrameworkCore;
using WebShop.Contracts;
using WebShop.Data;

namespace WebShop.Repository
{
    public class ArticlesRepository : GenericRepository<Article>, IArticlesRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticlesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Article> GetDetails(int id)
        {
            return await _context.Articles.Include(x => x.ColorInfos).ThenInclude(x => x.VariantInfos).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
