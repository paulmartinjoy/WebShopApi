using Microsoft.EntityFrameworkCore;
using WebShop.Contracts;
using WebShop.Data;

namespace WebShop.Repository
{
    public class ColorInfosRepository : GenericRepository<ColorInfo>, IColorInfosRepository
    {
        private readonly ApplicationDbContext _context;
        public ColorInfosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ColorInfo> GetDetails(int id)
        {
            return await _context.ColorInfos.Include(x => x.VariantInfos).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
