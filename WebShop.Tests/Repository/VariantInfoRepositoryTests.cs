using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models.ColorInfo;
using WebShop.Models.VariantInfo;
using WebShop.Repository;

namespace WebShop.Tests.Repository
{
    public class VariantInfoRepositoryTests
    {
        private readonly IMapper _mapper;
        public VariantInfoRepositoryTests()
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
            if (await databaseContext.VariantInfos.CountAsync() <= 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    databaseContext.VariantInfos.Add(
                     new VariantInfo
                     {
                         EAN = "2127495.5952.114/122",
                         SizeOrLengthInfo = "Size: medium, Length: 68cm, Sleeve length: short",
                         Price = 13.99,
                         AvailableStock = 15,
                         ColorInfoId = 1
                     });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void VariantInfoRepository_AddAsync_ReturnsVariantInfo()
        {
            //Arrange
            var variantInfo = new VariantInfo
            {
                EAN = "4556565.8552.114/150",
                SizeOrLengthInfo = "Size: medium, Length: 68cm, Sleeve length: short",
                Price = 13.99,
                AvailableStock = 100,
                ColorInfoId = 2
            };

            var dbContext = await GetDbContext();
            var variantInfosRepository = new VariantInfosRepository(dbContext);

            //Act
            var result = await variantInfosRepository.AddAsync(variantInfo);

            //Assert
            var addedVariantInfo = dbContext.VariantInfos.FirstOrDefault(a => a.Id == result.Id);
            Assert.NotNull(addedVariantInfo);
            Assert.Equal(variantInfo.EAN, addedVariantInfo.EAN);
        }

        [Fact]
        public async void VariantInfoRepository_DeleteVariantInfo()
        {
            //Arrange
            var variantInfoId = 1;
            var dbContext = await GetDbContext();
            var variantInfosRepository = new VariantInfosRepository(dbContext);

            //Act
            await variantInfosRepository.DeleteAsync(variantInfoId);

            //Assert
            var deletedVariantInfo = dbContext.Articles.FirstOrDefault(a => a.Id == variantInfoId);
            Assert.Null(deletedVariantInfo);
        }

        [Fact]
        public async void VariantInfoRepository_GetVariantInfos_ReturnsList()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var variantInfosRepository = new VariantInfosRepository(dbContext);

            //Act
            var result = await variantInfosRepository.GetAllAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<VariantInfo>>();
        }


        [Fact]
        public async void VariantInfoRepository_GetVariantInfo_ReturnsVariantInfo()
        {
            //Arrange
            int variantInfoId = 1;
            var dbContext = await GetDbContext();
            var variantInfosRepository = new VariantInfosRepository(dbContext);
            var variantInfo = A.Fake<VariantInfo>();
            var variantInfoDto = A.Fake<VariantInfoDto>();
            A.CallTo(() => _mapper.Map<VariantInfoDto>(variantInfo)).Returns(variantInfoDto);

            //Act
            var result = await variantInfosRepository.GetAsync(variantInfoId);

            //Assert
            result.Should().BeOfType<VariantInfo>();
        }
    }
}
