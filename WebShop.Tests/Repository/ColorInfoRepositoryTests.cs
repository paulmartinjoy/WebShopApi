using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models.Articles;
using WebShop.Models.ColorInfo;
using WebShop.Repository;

namespace WebShop.Tests.Repository
{
    public class ColorInfoRepositoryTests
    {
        private readonly IMapper _mapper;
        public ColorInfoRepositoryTests()
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
            if (await databaseContext.ColorInfos.CountAsync() <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    databaseContext.ColorInfos.Add(
                     new ColorInfo()
                     {
                         ColorName = "Navy",
                         ColorCode = "NVPOLO",
                         Pictures = new List<string>(),
                         ArticleId = 1
                     });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void ColorInfoRepository_AddAsync_ReturnsColorInfo()
        {
            //Arrange
            var colorInfo = new ColorInfo
            {
                ColorName = "Black",
                ColorCode = "JNSBL",
                Pictures = new List<string>(),
                ArticleId = 2
            };

            var dbContext = await GetDbContext();
            var colorInfosRepository = new ColorInfosRepository(dbContext);

            //Act
            var result = await colorInfosRepository.AddAsync(colorInfo);

            //Assert
            var addedColorInfo = dbContext.ColorInfos.FirstOrDefault(a => a.Id == result.Id);
            Assert.NotNull(addedColorInfo);
            Assert.Equal(colorInfo.ColorName, addedColorInfo.ColorName);
        }

        [Fact]
        public async void ColorInfoRepository_DeleteColorInfo()
        {
            //Arrange
            var colorInfoId = 1;
            var dbContext = await GetDbContext();
            var colorInfosRepository = new ColorInfosRepository(dbContext);

            //Act
            await colorInfosRepository.DeleteAsync(colorInfoId);

            //Assert
            var deletedColorInfo = dbContext.Articles.FirstOrDefault(a => a.Id == colorInfoId);
            Assert.Null(deletedColorInfo);
        }

        [Fact]
        public async void ColorInfoRepository_GetColorInfos_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var colorInfosRepository = new ColorInfosRepository(dbContext);

            //Act
            var result = await colorInfosRepository.GetAllAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<ColorInfo>>();
        }


        [Fact]
        public async void ColorInfoRepository_GetColorInfo_ReturnsColorInfo()
        {
            //Arrange
            int colorInfoId = 1;
            var dbContext = await GetDbContext();
            var colorInfosRepository = new ColorInfosRepository(dbContext);
            var colorInfo = A.Fake<ColorInfo>();
            var colorInfoDto = A.Fake<ColorInfoDto>();
            A.CallTo(() => _mapper.Map<ColorInfoDto>(colorInfo)).Returns(colorInfoDto);

            //Act
            var result = await colorInfosRepository.GetAsync(colorInfoId);

            //Assert
            result.Should().BeOfType<ColorInfo>();
        }
    }
}
