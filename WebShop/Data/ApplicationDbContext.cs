using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebShop.Data.Configurations;

namespace WebShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ColorInfo> ColorInfos { get; set; }
        public DbSet<VariantInfo> VariantInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new ColorInfoConfiguration());
            builder.ApplyConfiguration(new VariantInfoConfiguration());
            builder.Entity<ColorInfo>().Property(p => p.Pictures).HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<string>>(x));
        }
    }
}
