using WebShop.Data;

namespace WebShop.Contracts
{
    public interface IArticlesRepository : IGenericRepository<Article>
    {
        Task<Article> GetDetails(int id);
    }
}
