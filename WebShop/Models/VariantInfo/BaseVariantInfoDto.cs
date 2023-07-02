using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.VariantInfo
{
    public abstract class BaseVariantInfoDto
    {
        [Required]
        public string EAN { get; set; }
        public string? SizeOrLengthInfo { get; set; }
        public double? Price { get; set; }
        public int? AvailableStock { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ColorInfoId { get; set; }
    }
}
