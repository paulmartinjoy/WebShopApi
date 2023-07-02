using System.ComponentModel.DataAnnotations;
using WebShop.Data;

namespace WebShop.Models.Articles
{
    public abstract class BaseArticleDto
    {
        [Required]
        public string Name { get; set; }
        public string? Season { get; set; }

        [Required]
        [TwoDigit]
        public short CollectionType { get; set; }
        public string? CareInformation { get; set; }
        public string? FitInformation { get; set; }
        public string? MaterialInformation { get; set; }
    }
}
