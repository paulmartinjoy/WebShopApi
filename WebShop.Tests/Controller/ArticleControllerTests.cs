using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Formats.Asn1;
using WebShop.Contracts;
using WebShop.Controllers;
using WebShop.Data;
using WebShop.Models.Articles;

namespace WebShop.Tests.Controller
{
    public class ArticleControllerTests
    {
        private readonly IMapper _mapper;
        private readonly IArticlesRepository _articlesRepository;
        public ArticleControllerTests()
        {
            _mapper = A.Fake<IMapper>();
            _articlesRepository = A.Fake<IArticlesRepository>();
        }

        [Fact]
        public async Task ArticlesController_GetArticles_ReturnOK()
        {
            // Arrange
            var articles = A.Fake<ICollection<ArticleDto>>();
            var articlesList = A.Fake<List<ArticleDto>>();
            A.CallTo(() => _mapper.Map<List<ArticleDto>>(articles)).Returns(articlesList);
            var controller = new ArticlesController(_mapper, _articlesRepository);

            // Act
            var result = await controller.GetArticles();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            var articleDtos = (result.Result as OkObjectResult)?.Value as IEnumerable<ArticleDto>;
            articleDtos.Should().NotBeNull();
        }

        [Fact]
        public async Task ArticlesController_GetArticleById_ReturnOK()
        {
            //Arrange
            var id = 1;
            var article = A.Fake<Article>();
            var articleDto = A.Fake<ArticleDto>();
            A.CallTo(() => _mapper.Map<ArticleDto>(article)).Returns(articleDto);
            var controller = new ArticlesController(_mapper, _articlesRepository);

            //Act
            var result = await controller.GetArticle(1);

            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }
        
        [Fact]
        public async Task ArticlesController_PostArticle_CreatedAtAction()
        {
            //Arrange
            var article = A.Fake<Article>();
            var createArticleDto = A.Fake<CreateArticleDto>();
            A.CallTo(() => _mapper.Map<Article>(createArticleDto)).Returns(article);
            var controller = new ArticlesController(_mapper, _articlesRepository);

            //Act
            var result = await controller.PostArticle(createArticleDto);

            //Assert
            result.Result.Should().BeOfType<CreatedAtActionResult>();
            var articleDtos = (result.Result as CreatedAtActionResult)?.Value as Article;
            articleDtos.Should().NotBeNull();
        }
    }    
}
