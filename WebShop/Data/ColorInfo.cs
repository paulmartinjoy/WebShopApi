using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data
{
    public class ColorInfo
    {
        public int Id { get; set; }
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public List<string>? Pictures { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public int ArticleId { get; set; }
        public Article? Article { get; set; }
        public virtual IList<VariantInfo>? VariantInfos { get; set; }
    }
}
