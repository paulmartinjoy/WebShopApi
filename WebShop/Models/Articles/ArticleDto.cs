using WebShop.Models.ColorInfo;

namespace WebShop.Models.Articles
{
    public class ArticleDto : BaseArticleDto
    {
        public int Id { get; set; }
        public List<ColorInfoDto>? ColorInfos { get; set; }
    }
}
