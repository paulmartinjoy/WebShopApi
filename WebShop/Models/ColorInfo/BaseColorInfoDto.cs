using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.ColorInfo
{
    public abstract class BaseColorInfoDto
    {
        [Required]
        public string ColorName { get; set; }
        public string? ColorCode { get; set; }
        public List<string>? Pictures { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ArticleId { get; set; }

    }
}
