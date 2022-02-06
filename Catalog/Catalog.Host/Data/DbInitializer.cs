using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Brands.Any())
            {
                await context.Brands.AddRangeAsync(GetPreconfiguredBrands());

                await context.SaveChangesAsync();
            }

            if (!context.OperationSystems.Any())
            {
                await context.OperationSystems.AddRangeAsync(GetPreconfiguredOperationSystems());

                await context.SaveChangesAsync();
            }

            if (!context.Mobiles.Any())
            {
                await context.Mobiles.AddRangeAsync(GetPreconfiguredMobiles());

                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Brand> GetPreconfiguredBrands()
        {
            return new List<Brand>()
            {
                new() { Id = 1, Name = "Apple" },
                new() { Id = 2, Name ="Huawey" },
                new() { Id = 3, Name = "Motorola" },
                new() { Id = 4, Name = "Nokia" },
                new() { Id = 5, Name = "OPPO"},
                new() { Id = 6, Name = "OnePlus"},
                new() { Id = 7, Name = "Poco"},
                new() { Id = 8, Name = "RealMe"},
                new() { Id = 9, Name = "Samsung"},
                new() { Id = 10, Name = "Xiaomi"},
                new() { Id = 11, Name = "ZTE"}
            };
        }

        private static IEnumerable<OperationSystem> GetPreconfiguredOperationSystems()
        {
            return new List<OperationSystem>()
            {
                new() { Id = 1, Name = "Android" },
                new() { Id = 2, Name = "BlackBerry" },
                new() { Id = 3, Name = "iOS" }
            };
        }

        private static IEnumerable<Mobile> GetPreconfiguredMobiles()
        {
            return new List<Mobile>()
            {
                new()
                {
                    Id = 1,
                    Name = "iPhone 11 128GB Black Slim Box",
                    Price = 20999M,
                    PictureFileName = "https://content.rozetka.com.ua/goods/images/big/37399233.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        Дисплей
                        Диагональ экрана
                        6.1
                        Разрешение дисплея
                        1792 x 828
                        Тип матрицы
                        IPS",
                    BrandId = 1,
                    OperationSystemId = 3,
                    AvailableStock = 2                        
                },
                new()
                {
                    Id = 2,
                    Name = "Apple iPhone 13 Pro Max 256GB Sierra Blue",
                    Price = 44999M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/221290006.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        5G
                        Дисплей
                        Диагональ экрана
                        6.7
                        Разрешение дисплея
                        2778x1284
                        Тип матрицы
                        OLED (Super Retina XDR)
                        Частота обновления экрана
                        120 Гц",
                    BrandId = 1,
                    OperationSystemId = 3,
                    AvailableStock = 1
                },
                new()
                {
                    Id = 3,
                    Name = "Apple iPhone 13 128GB Blue",
                    Price = 29999M,
                    PictureFileName = "https://content.rozetka.com.ua/goods/images/big/221214143.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        5G
                        Дисплей
                        Диагональ экрана
                        6.1
                        Разрешение дисплея
                        2532x1170
                        Тип матрицы
                        OLED (Super Retina XDR)
                        Частота обновления экрана
                        60 Гц",
                    BrandId = 1,
                    OperationSystemId = 3,
                    AvailableStock = 3
                },
                new()
                {
                    Id = 4,
                    Name = "Huawei P Smart 2021 NFC 128GB Green",
                    Price = 4799M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/163104727.png",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        Дисплей
                        Диагональ экрана
                        6.67
                        Разрешение дисплея
                        2400 x 1080
                        Тип матрицы
                        IPS",
                    BrandId = 2,
                    OperationSystemId = 1,
                    AvailableStock = 1
                },
                new()
                {
                    Id = 5,
                    Name = "Huawei Nova 8i 6/128GB Moonlight Silver",
                    Price = 8999M,
                    PictureFileName = "https://content1.rozetka.com.ua/goods/images/big/230224784.jpg",
                    Description = @"Стандарт связи
                        2G (GSM)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        Дисплей
                        Диагональ экрана
                        6.67
                        Разрешение дисплея
                        2376 x 1080
                        Тип матрицы
                        IPS",
                    BrandId = 2,
                    OperationSystemId = 1,
                    AvailableStock = 5
                },
                new()
                {
                    Id = 6,
                    Name = "Motorola Moto G60 6/128GB Haze Gray",
                    Price = 6999M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/220713124.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        Дисплей
                        Диагональ экрана
                        6.8
                        Разрешение дисплея
                        2460 x 1080
                        Тип матрицы
                        IPS
                        Частота обновления экрана
                        120 Гц",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                },
                new()
                {
                    Id = 7,
                    Name = "Motorola E7 Power 4/64GB Tahiti Blue",
                    Price = 3499M,
                    PictureFileName = "https://content.rozetka.com.ua/goods/images/big/188975851.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        Дисплей
                        Диагональ экрана
                        6.5
                        Разрешение дисплея
                        1600 х 720
                        Тип матрицы
                        IPS
                        Частота обновления экрана
                        60 Гц",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                },
                new()
                {
                    Id = 8,
                    Name = "Motorola E6i 2/32GB Meteor Grey",
                    Price = 2899M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/188927047.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        Дисплей
                        Диагональ экрана
                        6.1
                        Разрешение дисплея
                        1560 x 720
                        Тип матрицы
                        IPS
                        Частота обновления экрана
                        60 Гц",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                },
                new()
                {
                    Id = 9,
                    Name = "Motorola Moto Edge 20 Pro 12/256GB Midnight Blue",
                    Price = 17999M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/221069029.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        5G
                        Дисплей
                        Диагональ экрана
                        6.67
                        Разрешение дисплея
                        2400 x 1080
                        Тип матрицы
                        OLED
                        Частота обновления экрана
                        144 Гц",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                },
                new()
                {
                    Id = 10,
                    Name = "Motorola G200 5G 8/128GB Stellar Blue",
                    Price = 15999M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/243884320.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        5G
                        Дисплей
                        Диагональ экрана
                        6.8
                        Разрешение дисплея
                        2460x1080
                        Тип матрицы
                        IPS
                        Частота обновления экрана
                        144 Гц",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                },
                new()
                {
                    Id = 11,
                    Name = "Motorola G100 8/128GB Iridescent Ocean",
                    Price = 11999M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/189057862.jpg",
                    Description = @"Стандарт связи
                        2G (GPRS/EDGE)
                        3G (WCDMA/UMTS/HSPA)
                        4G (LTE)
                        5G
                        Дисплей
                        Диагональ экрана
                        6.7
                        Разрешение дисплея
                        2520х1080
                        Тип матрицы
                        LCD
                        Частота обновления экрана
                        90 Гц",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                },
                new()
                {
                    Id = 12,
                    Name = "Motorola Razr 5G 8/256GB Graphite",
                    Price = 64799M,
                    PictureFileName = "https://content2.rozetka.com.ua/goods/images/big/169925194.jpg",
                    Description = @"Стандарт связи
                        3G
                        4G (LTE)
                        5G
                        CDMA
                        GSM
                        Дисплей
                        Диагональ экрана
                        6.2
                        Тип матрицы
                        P-OLED
                        Материал экрана
                        Стекло",
                    BrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2
                }
            };
        }
    }
}
