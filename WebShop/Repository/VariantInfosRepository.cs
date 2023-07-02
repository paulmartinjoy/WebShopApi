using WebShop.Contracts;
using WebShop.Data;

namespace WebShop.Repository
{
    public class VariantInfosRepository : GenericRepository<VariantInfo>, IVariantInfosRepository
    {
        public VariantInfosRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
