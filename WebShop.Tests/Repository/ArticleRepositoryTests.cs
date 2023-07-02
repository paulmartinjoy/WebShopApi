using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Contracts;
using WebShop.Data;
using WebShop.Models.Articles;
using WebShop.Repository;
using Xunit;

namespace WebShop.Tests.Repository
{
    public class ArticleRepositoryTests
    {
        private readonly IMapper _mapper;
        public ArticleRepositoryTests()
        {
            _mapper = A.Fake<IMapper>();
        }

        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Articles.CountAsync() <= 0)
            {
                for(int i = 0; i < 5; i++)
                {
                    databaseContext.Articles.Add(new Article()
                    {
                        Name = "Classic Poloshirt",
                        Season = "202305",
                        CollectionType = 10,
                        CareInformation = "Gentle cycle 30 degrees, Chlorine bleach not possible",
                        FitInformation = "Fit: Regular fit, Length: 68cm",
                        MaterialInformation = "Fabric: Cotton, Quality: soft"
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void ArticleRepository_AddAsync_ReturnsArticle()
        {
            //Arrange
            var article = new Article
            {
                Name = "Slim leg Jeans",
                Season = "202301",
                CollectionType = 15,
                CareInformation = "Gentle cycle 30 degrees, Chlorine bleach not possible",
                FitInformation = "Fit: Slim fit, Rise: Mid rise",
                MaterialInformation = "Fabric: Denim, Quality: elastic"
            };

            var dbContext = await GetDbContext();
            var articleRepository = new ArticlesRepository(dbContext);

            //Act
            var result = await articleRepository.AddAsync(article);

            //Assert
            var addedArticle = dbContext.Articles.FirstOrDefault(a => a.Id == result.Id);
            Assert.NotNull(addedArticle);
            Assert.Equal(article.Name, addedArticle.Name);
        }

        [Fact]
        public async void ArticleRepository_DeleteArticle()
        {
            //Arrange
            var articleId = 1;
            var dbContext = await GetDbContext();
            var articleRepository = new ArticlesRepository(dbContext);

            //Act
            await articleRepository.DeleteAsync(articleId);

            //Assert
            var deletedArticle = dbContext.Articles.FirstOrDefault(a => a.Id == articleId);
            Assert.Null(deletedArticle);
        }

        [Fact]
        public async void ArticleRepository_GetArticles_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var articleRepository = new ArticlesRepository(dbContext);

            //Act
            var result = await articleRepository.GetAllAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Article>>();
        }


        [Fact]
        public async void ArticleRepository_GetArticle_ReturnsArticle()
        {
            //Arrange
            int articleId = 1;
            var dbContext = await GetDbContext();
            var articleRepository = new ArticlesRepository(dbContext);
            var article = A.Fake<Article>();
            var articleDto = A.Fake<ArticleDto>();
            A.CallTo(() => _mapper.Map<ArticleDto>(article)).Returns(articleDto);

            //Act
            var result = await articleRepository.GetAsync(articleId);

            //Assert
            result.Should().BeOfType<Article>();
        }
    }
}
