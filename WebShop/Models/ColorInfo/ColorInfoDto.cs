using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Data;
using WebShop.Models.VariantInfo;

namespace WebShop.Models.ColorInfo
{
    public class ColorInfoDto : BaseColorInfoDto
    {
        public int Id { get; set; }
        public List<VariantInfoDto>? VariantInfos { get; set; }
    }
}
