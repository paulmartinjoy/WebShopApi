using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebShop.Data.Configurations
{
    public class VariantInfoConfiguration : IEntityTypeConfiguration<VariantInfo>
    {
        public void Configure(EntityTypeBuilder<VariantInfo> builder)
        {
            builder.HasData(
                new VariantInfo
                {
                    Id = 1,
                    EAN = "2127495.5952.114/122",
                    SizeOrLengthInfo = "Size: medium, Length: 68cm, Sleeve length: short",
                    Price = 13.99,
                    AvailableStock = 15,
                    ColorInfoId = 1
                },
                new VariantInfo
                {
                    Id = 2,
                    EAN = "4556565.8552.114/150",
                    SizeOrLengthInfo = "Size: medium, Length: 68cm, Sleeve length: short",
                    Price = 13.99,
                    AvailableStock = 100,
                    ColorInfoId = 2
                },
                new VariantInfo
                {
                    Id = 3,
                    EAN = "256985.600.200/122",
                    SizeOrLengthInfo = "Size: medium, Length: 68cm, Sleeve length: long",
                    Price = 13.99,
                    AvailableStock = 21,
                    ColorInfoId = 3
                }
            );
        }
    }
}
