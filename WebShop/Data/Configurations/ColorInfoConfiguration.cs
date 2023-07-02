using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebShop.Data.Configurations
{
    public class ColorInfoConfiguration : IEntityTypeConfiguration<ColorInfo>
    {
        public void Configure(EntityTypeBuilder<ColorInfo> builder)
        {
            builder.HasData(
                new ColorInfo
                {
                    Id = 1,
                    ColorName = "Navy",
                    ColorCode = "NVPOLO",
                    Pictures = new List<string>(),
                    ArticleId = 1
                },
                new ColorInfo
                {
                    Id = 2,
                    ColorName = "Black",
                    ColorCode = "JNSBL",
                    Pictures = new List<string>(),
                    ArticleId = 2
                },
                new ColorInfo
                {
                    Id = 3,
                    ColorName = "Red",
                    ColorCode = "RDJCKT",
                    Pictures = new List<string>(),
                    ArticleId = 3
                }
            );
        }
    }
}
