using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Contracts;
using WebShop.Controllers;
using WebShop.Data;
using WebShop.Models.Articles;
using WebShop.Models.ColorInfo;

namespace WebShop.Tests.Controller
{
    public class ColorInfoControllerTests
    {
        private readonly IColorInfosRepository _colorInfosRepository;
        private readonly IArticlesRepository _articlesRepository;
        private readonly IMapper _mapper;
        public ColorInfoControllerTests()
        {
            _colorInfosRepository = A.Fake<IColorInfosRepository>();
            _articlesRepository = A.Fake<IArticlesRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task ColorInfosController_GetColorInfos_ReturnOK()
        {
            // Arrange
            var colorInfos = A.Fake<ICollection<ColorInfoDto>>();
            var colorInfosList = A.Fake<List<ColorInfoDto>>();
            A.CallTo(() => _mapper.Map<List<ColorInfoDto>>(colorInfos)).Returns(colorInfosList);
            var controller = new ColorInfosController(_colorInfosRepository, _articlesRepository, _mapper);

            // Act
            var result = await controller.GetColorInfos();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            var colorInfoDtos = (result.Result as OkObjectResult)?.Value as IEnumerable<ColorInfoDto>;
            colorInfoDtos.Should().NotBeNull();
        }

        [Fact]
        public async Task ColorInfosController_GetColorInfoById_ReturnOK()
        {
            //Arrange
            var id = 1;
            var colorInfo = A.Fake<ColorInfo>();
            var colorInfoDto = A.Fake<ColorInfoDto>();
            A.CallTo(() => _mapper.Map<ColorInfoDto>(colorInfo)).Returns(colorInfoDto);
            var controller = new ColorInfosController(_colorInfosRepository, _articlesRepository, _mapper);

            //Act
            var result = await controller.GetColorInfo(1);

            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        //[Fact]
        //public async Task ColorInfosController_PostColorInfo_CreatedAtAction()
        //{
        //    //Arrange
        //    var colorInfo = A.Fake<ColorInfo>();
        //    var createColorInfoDto = A.Fake<CreateArticleDto>();
        //    A.CallTo(() => _mapper.Map<ColorInfo>(createColorInfoDto)).Returns(colorInfo);
        //    var controller = new ColorInfosController(_colorInfosRepository, _articlesRepository, _mapper);

        //    //Act
        //    var result = await controller.PostColorInfo(createColorInfoDto);

        //    //Assert
        //    result.Result.Should().BeOfType<CreatedAtActionResult>();
        //    var articleDtos = (result.Result as CreatedAtActionResult)?.Value as ColorInfo;
        //    articleDtos.Should().NotBeNull();
        //}
    }
}
