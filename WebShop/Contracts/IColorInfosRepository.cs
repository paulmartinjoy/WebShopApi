using WebShop.Data;

namespace WebShop.Contracts
{
    public interface IColorInfosRepository : IGenericRepository<ColorInfo>
    {
        Task<ColorInfo> GetDetails(int id);
    }
}
