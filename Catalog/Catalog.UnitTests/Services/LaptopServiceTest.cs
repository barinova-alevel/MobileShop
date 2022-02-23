using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Infrastructure;

namespace Catalog.UnitTests.Services
{
    public class LaptopServiceTest
    {
        private readonly ILaptopService _laptopService;

        private readonly Mock<ILaptopRepository> _laptopRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<LaptopService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly Laptop _testLaptop = new Laptop()
        {
            Name = "NewLaptop",
            Description = "Description of Laptop",
            Price = 1000,
            PictureFileName = "1.png",
            LaptopBrandId = 1,
            ScreenTypeId = 1,
            AvailableStock = 100,
            Sku = "99999999"
        };

        public LaptopServiceTest()
        {
            _laptopRepository = new Mock<ILaptopRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<LaptopService>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

            _laptopService = new LaptopService(_dbContextWrapper.Object, _logger.Object, _laptopRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // arrange
            var testResult = 1;

            _laptopRepository.Setup(s => s.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _laptopService.AddAsync(
                _testLaptop.Name,
                _testLaptop.Description,
                _testLaptop.Price,
                _testLaptop.PictureFileName,
                _testLaptop.LaptopBrandId,
                _testLaptop.ScreenTypeId,
                _testLaptop.AvailableStock,
                _testLaptop.Sku);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // arrange
            int? testResult = null;

            _laptopRepository.Setup(s => s.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _laptopService.AddAsync(
                _testLaptop.Name,
                _testLaptop.Description,
                _testLaptop.Price,
                _testLaptop.PictureFileName,
                _testLaptop.LaptopBrandId,
                _testLaptop.ScreenTypeId,
                _testLaptop.AvailableStock,
                _testLaptop.Sku);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetLaptopsAsync_UseValidParameters_ReturnCorrespondigData()
        {
            // Arrange
            var pageIndex = 1;
            var pageSize = 2;
            var filter = new LaptopFilter();
            var laptop1 = new Laptop()
            {
                Name = "Name1"
            };
            var laptop2 = new Laptop()
            {
                Name = "Name2"
            };
            _laptopRepository
               .Setup(_ => _.GetByPageAsync(It.IsAny<Specification<Laptop>>(), It.IsAny<int>(), It.IsAny<int>()))
               .ReturnsAsync(new PaginatedItems<Laptop>()
               {
                   TotalCount = 2,
                   Data = new List<Laptop>() { laptop1, laptop2 }
               });
            _mapper
                .Setup(s => s.Map<LaptopDto>(It.Is<Laptop>(_ => _ == laptop1)))
                .Returns(new LaptopDto { Name = "Name1" });
            _mapper
                .Setup(s => s.Map<LaptopDto>(It.Is<Laptop>(_ => _ == laptop2)))
                .Returns(new LaptopDto { Name = "Name2" });

            // Act
            var result = await _laptopService.GetLaptopsAsync(filter, pageSize, pageIndex);

            // Assert
            result.Should().NotBeNull();
            result?.PageIndex.Should().Be(pageIndex);
            result?.PageSize.Should().Be(pageSize);
            result?.Count.Should().Be(2);
            result?.Data.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task GetLaptopsAsync_UseZeroPageIndexPageSize_ReturnEmptyData()
        {
            // Arrange
            _laptopRepository
                .Setup(_ => _.GetByPageAsync(It.IsAny<Specification<Laptop>>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new PaginatedItems<Laptop>()
                {
                    Data = new List<Laptop>()
                });

            // Act
            var result = await _laptopService.GetLaptopsAsync(new (), 0, 0);

            // Assert
            result.Should().NotBeNull();
            result?.PageIndex.Should().Be(0);
            result?.PageSize.Should().Be(0);
            result?.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task GetLaptopsAsync_InvalidPageIndex_ReturnNull()
        {
            // Arrange
            const int invalidIndex = 1;
            _laptopRepository
                .Setup(_ => _.GetByPageAsync(It.IsAny<Specification<Laptop>>(), It.Is<int>(i => i == invalidIndex), It.IsAny<int>()))
                .ReturnsAsync((PaginatedItems<Laptop>)null!);

            // Act
            var result = await _laptopService.GetLaptopsAsync(new (), 10, invalidIndex);

            // Assert
            result.Should().BeNull();
        }
    }
}
