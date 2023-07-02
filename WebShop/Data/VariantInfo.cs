using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data
{
    public class VariantInfo
    {
        public int Id { get; set; }
        public string? EAN { get; set; }
        public string? SizeOrLengthInfo { get; set; }
        public double? Price { get; set; }
        public int? AvailableStock { get; set; }

        [ForeignKey(nameof(ColorInfoId))]
        public int ColorInfoId { get; set; }
        public ColorInfo? ColorInfo { get; set; }
    }
}
