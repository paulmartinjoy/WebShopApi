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
using WebShop.Models.ColorInfo;
using WebShop.Models.VariantInfo;
using WebShop.Repository;

namespace WebShop.Tests.Controller
{
    public class VariantInfosControllerTests
    {
        private readonly IVariantInfosRepository _variantInfosRepository;
        private readonly IColorInfosRepository _colorInfosRepository;
        private readonly IMapper _mapper;
        public VariantInfosControllerTests()
        {
            _variantInfosRepository = A.Fake<IVariantInfosRepository>();
            _colorInfosRepository = A.Fake<IColorInfosRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task VariantInfosController_GetVariantInfos_ReturnOK()
        {
            // Arrange
            var variantInfos = A.Fake<ICollection<VariantInfo>>();
            var variantInfosList = A.Fake<List<VariantInfoDto>>();
            A.CallTo(() => _mapper.Map<List<VariantInfoDto>>(variantInfos)).Returns(variantInfosList);
            var controller = new VariantInfosController(_variantInfosRepository, _colorInfosRepository,  _mapper);

            // Act
            var result = await controller.GetVariantInfos();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            var variantInfoDtos = (result.Result as OkObjectResult)?.Value as IEnumerable<VariantInfoDto>;
            variantInfoDtos.Should().NotBeNull();
        }

        [Fact]
        public async Task ColorInfosController_GetColorInfoById_ReturnOK()
        {
            //Arrange
            var id = 1;
            var variantInfo = A.Fake<VariantInfo>();
            var variantInfoDto = A.Fake<VariantInfoDto>();
            A.CallTo(() => _mapper.Map<VariantInfoDto>(variantInfo)).Returns(variantInfoDto);
            var controller = new VariantInfosController(_variantInfosRepository, _colorInfosRepository, _mapper);

            //Act
            var result = await controller.GetVariantInfo(1);

            //Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
