using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebShop.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
               new Article
               {
                   Id = 1,
                   Name = "Classic Poloshirt",
                   Season = "202305",
                   CollectionType = 10,
                   CareInformation = "Gentle cycle 30 degrees, Chlorine bleach not possible",
                   FitInformation = "Fit: Regular fit, Length: 68cm",
                   MaterialInformation = "Fabric: Cotton, Quality: soft"
               },
                new Article
                {
                    Id = 2,
                    Name = "Slim leg Jeans",
                    Season = "202301",
                    CollectionType = 15,
                    CareInformation = "Gentle cycle 30 degrees, Chlorine bleach not possible",
                    FitInformation = "Fit: Slim fit, Rise: Mid rise",
                    MaterialInformation = "Fabric: Denim, Quality: elastic"
                },
                new Article
                {
                    Id = 3,
                    Name = "Hooded Quilted Jacket",
                    Season = "202209",
                    CollectionType = 20,
                    CareInformation = "Gentle cycle 30 degrees, Chlorine bleach not possible",
                    FitInformation = "Fit: Regular fit, Length: 58cm",
                    MaterialInformation = "Fabric: Woven, Quality: light, Filling: lightly padded"
                }
            );
        }
    }
}
