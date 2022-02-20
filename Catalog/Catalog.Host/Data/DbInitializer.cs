using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeMobiles(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.MobileBrands.Any())
            {
                await context.MobileBrands.AddRangeAsync(GetPreconfiguredMobileBrands());

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

        public static async Task InitializeLaptops(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.LaptopBrands.Any())
            {
                await context.LaptopBrands.AddRangeAsync(GetPreconfiguredLaptopBrands());

                await context.SaveChangesAsync();
            }

            if (!context.ScreenTypes.Any())
            {
                await context.ScreenTypes.AddRangeAsync(GetPreconfiguredScreenTypes());

                await context.SaveChangesAsync();
            }

            if (!context.Laptops.Any())
            {
                await context.Laptops.AddRangeAsync(GetPreconfiguredLaptops());

                await context.SaveChangesAsync();
            }
        }
        private static IEnumerable<MobileBrand> GetPreconfiguredMobileBrands()
        {
            return new List<MobileBrand>()
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

        private static IEnumerable<LaptopBrand> GetPreconfiguredLaptopBrands()
        {
            return new List<LaptopBrand>()
            {
                new() { Id = 1, Name = "Asus" },
                new() { Id = 2, Name = "Acer" },
                new() { Id = 3, Name = "Apple" },
                new() { Id = 4, Name = "Dell" },
                new() { Id = 5, Name = "HP"},
                new() { Id = 6, Name = "Huawei"},
                new() { Id = 7, Name = "Microsoft"},
                new() { Id = 8, Name = "Lenovo"}
            };
        }

        private static IEnumerable<MobileOs> GetPreconfiguredOperationSystems()
        {
            return new List<MobileOs>()
            {
                new() { Id = 1, Name = "Android" },
                new() { Id = 2, Name = "BlackBerry" },
                new() { Id = 3, Name = "iOS" }
            };
        }

        private static IEnumerable<LaptopScreenType> GetPreconfiguredScreenTypes()
        {
            return new List<LaptopScreenType>()
            {
                new() { Id = 1, Name = "AMOLED" },
                new() { Id = 2, Name = "IPS" },
                new() { Id = 3, Name = "OLED" },
                new() { Id = 4, Name = "Retina" },
                new() { Id = 5, Name = "SVA" },
                new() { Id = 6, Name = "WVA" },
                new() { Id = 7, Name = "LTPS" },
                new() { Id = 8, Name = "TN" },
                new() { Id = 9, Name = "UWVA" },
                new() { Id = 10, Name = "VA" }
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
                    PictureFileName = "37399233.jpg",
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
                    MobileBrandId = 1,
                    OperationSystemId = 3,
                    AvailableStock = 2,
                    Sku = "318258"
                },
                new()
                {
                    Id = 2,
                    Name = "Apple iPhone 13 Pro Max 256GB Sierra Blue",
                    Price = 44999M,
                    PictureFileName = "221290006.jpg",
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
                    MobileBrandId = 1,
                    OperationSystemId = 3,
                    AvailableStock = 1,
                    Sku = "376884"
                },
                new()
                {
                    Id = 3,
                    Name = "Apple iPhone 13 128GB Blue",
                    Price = 29999M,
                    PictureFileName = "221214143.jpg",
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
                    MobileBrandId = 1,
                    OperationSystemId = 3,
                    AvailableStock = 3,
                    Sku = "675384"
                },
                new()
                {
                    Id = 4,
                    Name = "Huawei P Smart 2021 NFC 128GB Green",
                    Price = 4799M,
                    PictureFileName = "163104727.png",
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
                    MobileBrandId = 2,
                    OperationSystemId = 1,
                    AvailableStock = 1,
                    Sku = "904105"
                },
                new()
                {
                    Id = 5,
                    Name = "Huawei Nova 8i 6/128GB Moonlight Silver",
                    Price = 8999M,
                    PictureFileName = "230224784.jpg",
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
                    MobileBrandId = 2,
                    OperationSystemId = 1,
                    AvailableStock = 5,
                    Sku = "152549"
                },
                new()
                {
                    Id = 6,
                    Name = "Motorola Moto G60 6/128GB Haze Gray",
                    Price = 6999M,
                    PictureFileName = "220713124.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "561249"
                },
                new()
                {
                    Id = 7,
                    Name = "Motorola E7 Power 4/64GB Tahiti Blue",
                    Price = 3499M,
                    PictureFileName = "188975851.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "223812"
                },
                new()
                {
                    Id = 8,
                    Name = "Motorola E6i 2/32GB Meteor Grey",
                    Price = 2899M,
                    PictureFileName = "188927047.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "644280"
                },
                new()
                {
                    Id = 9,
                    Name = "Motorola Moto Edge 20 Pro 12/256GB Midnight Blue",
                    Price = 17999M,
                    PictureFileName = "221069029.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "813744"
                },
                new()
                {
                    Id = 10,
                    Name = "Motorola G200 5G 8/128GB Stellar Blue",
                    Price = 15999M,
                    PictureFileName = "243884320.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "797822"
                },
                new()
                {
                    Id = 11,
                    Name = "Motorola G100 8/128GB Iridescent Ocean",
                    Price = 11999M,
                    PictureFileName = "189057862.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "250969"
                },
                new()
                {
                    Id = 12,
                    Name = "Motorola Razr 5G 8/256GB Graphite",
                    Price = 64799M,
                    PictureFileName = "169925194.jpg",
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
                    MobileBrandId = 3,
                    OperationSystemId = 1,
                    AvailableStock = 2,
                    Sku = "651165"
                }
            };
        }
        private static IEnumerable<Laptop> GetPreconfiguredLaptops()
        {
            return new List<Laptop>()
            {
                new()
                {
                    Id = 1,
                    Name = "HP Pavilion Gaming 15-ec2013ua (4A7M9EA) Shadow Black",
                    Description = @"Процессор
                        Шестиядерный AMD Ryzen 5 5600H (3.3 - 4.2 ГГц)
                        Операционная система
                        DOS
                        Выбор языка в предустановленной Windows
                        украинский",
                    Price = 24999M,
                    PictureFileName = "247214370.jpg",
                    LaptopBrandId = 5,
                    ScreenTypeId = 2,
                    AvailableStock = 2,
                    Sku = "995657"
                },
                new()
                {
                    Id = 2,
                    Name = "ASUS Laptop X415FA-EB013 (90NB0W12-M00150) Slate Grey",
                    Description = @"Процессор
                        Двухъядерный Intel Core i3-10110U (2.1 - 4.1 ГГц)
                        Операционная система
                        Без ОС
                        Поколение процессора Intel
                        10-ое Comet Lake",
                    Price = 14444M,
                    PictureFileName = "252123791.jpg",
                    LaptopBrandId = 1,
                    ScreenTypeId = 2,
                    AvailableStock = 1,
                    Sku = "995657"
                },
                new()
                {
                    Id = 3,
                    Name = "Acer Aspire 5 A515-45G-R9ML (NX.A8CEU.00N) Pure Silver",
                    Description = @"Процессор
                        Шестиядерный AMD Ryzen 5 5500U (2.1 - 4.0 ГГц)
                        Операционная система
                        Без ОС",
                    Price = 20999M,
                    PictureFileName = "248481392.jpg",
                    LaptopBrandId = 2,
                    ScreenTypeId = 2,
                    AvailableStock = 1,
                    Sku = "919771"
                },
                new()
                {
                    Id = 4,
                    Name = "ASUS VivoBook 15 OLED M513UA-L1177 (90NB0TP1-M02620) Indie Black",
                    Description = @"Процессор
                        Шестиядерный AMD Ryzen 5 5500U (2.1 - 4.0 ГГц)
                        Операционная система
                        Без ОС",
                    Price = 23999M,
                    PictureFileName = "231724078.jpg",
                    LaptopBrandId = 1,
                    ScreenTypeId = 3,
                    AvailableStock = 2,
                    Sku = "764312"
                },
                new()
                {
                    Id = 5,
                    Name = "Lenovo ThinkPad T15g Gen 1 (20UR0030RT) Black",
                    Description = @"Процессор
                        Шестиядерный Intel Xeon W-10855M (2.8 - 5.1 ГГц)
                        Операционная система
                        Windows 10 Pro 64bit
                        Поколение процессора Intel
                        10-ое Comet Lake",
                    Price = 188243M,
                    PictureFileName = "175199396.jpg",
                    LaptopBrandId = 8,
                    ScreenTypeId = 3,
                    AvailableStock = 2,
                    Sku = "292346"
                },
                new()
                {
                    Id = 6,
                    Name = "HP ZBook Studio G8 (314G8EA) Turbo Silver",
                    Description = @"Процессор
                        Восьмиядерный Intel Core i7-11850H (2.5 - 4.8 ГГц)
                        Операционная система
                        Windows 10 Pro 64bit
                        Поколение процессора Intel
                        11-ое Tiger Lake",
                    Price = 121599M,
                    PictureFileName = "240968284.jpg",
                    LaptopBrandId = 5,
                    ScreenTypeId = 3,
                    AvailableStock = 1,
                    Sku = "154985"
                },
                new()
                {
                    Id = 7,
                    Name = "Apple MacBook Air 13 M1 256GB 2020 (MGN63) Space Gray",
                    Description = @"Процессор
                        Восьмиядерный Apple M1
                        Операционная система
                        macOS Big Sur",
                    Price = 33999M,
                    PictureFileName = "144249716.jpg",
                    LaptopBrandId = 3,
                    ScreenTypeId = 4,
                    AvailableStock = 1,
                    Sku = "377682"
                },
                new()
                {
                    Id = 8,
                    Name = "Apple MacBook Pro 13 M1 256GB 2020 (Z11B000Q8) Custom Space Gray",
                    Description = @"Процессор
                        Восьмиядерный Apple M1
                        Операционная система
                        macOS Big Sur
                        ",
                    Price = 55499M,
                    PictureFileName = "175329107.jpg",
                    LaptopBrandId = 3,
                    ScreenTypeId = 4,
                    AvailableStock = 1,
                    Sku = "892591"
                },
                new()
                {
                    Id = 9,
                    Name = "HP 250 G8 (2W9A7EA) Asteroid Silver",
                    Description = @"Процессор
                        Двухъядерный Intel Core i3-1115G4 (3.0 - 4.1 ГГц)
                        Операционная система
                        Windows 10 Pro 64bit
                        Поколение процессора Intel
                        11-ое Tiger Lake",
                    Price = 23999M,
                    PictureFileName = "183731943.jpg",
                    LaptopBrandId = 5,
                    ScreenTypeId = 5,
                    AvailableStock = 1,
                    Sku = "492146"
                },
                new()
                {
                    Id = 10,
                    Name = "Dell Latitude 5420 (N005L542014UA_WP) Silver",
                    Description = @"Процессор
                        Четырехъядерный Intel Core i5-1135G7 (2.4 - 4.2 ГГц)
                        Операционная система
                        Windows 10 Pro 64bit
                        Поколение процессора Intel
                        11-ое Tiger Lake",
                    Price = 38052M,
                    PictureFileName = "194685288.jpg",
                    LaptopBrandId = 4,
                    ScreenTypeId = 6,
                    AvailableStock = 1,
                    Sku = "098857"
                },
                new()
                {
                    Id = 11,
                    Name = "Dell Vostro 5510 (N5111VN5510UA01_2201_UBU) Titan Grey",
                    Description = @"Процессор
                        Четырехъядерный Intel Core i5-11300H (2.6 - 4.4 ГГц)
                        Операционная система
                        Ubuntu
                        Поколение процессора Intel
                        11-ое Tiger Lake
                        Диагональ экрана
                        15.6 (1920x1080) Full HD
                        Тип экрана
                        WVA
                        Частота обновления экрана
                        60 Гц",
                    Price = 27399M,
                    PictureFileName = "196193058.jpg",
                    LaptopBrandId = 4,
                    ScreenTypeId = 6,
                    AvailableStock = 1,
                    Sku = "380860"
                },
                new()
                {
                    Id = 12,
                    Name = "Huawei MateBook 14s (53012LVG) Space Gray",
                    Description = @"Процессор
                        Четырехъядерный Intel Core i5-11300H (2.6 - 4.4 ГГц)
                        Операционная система
                        Windows 10 Home 64bit
                        Поколение процессора Intel
                        11-ое Tiger Lake
                        Выбор языка в предустановленной Windows
                        украинский, русский
                        Диагональ экрана
                        14.2 (2520x1680) Multitouch
                        Тип экрана
                        LTPS
                        Частота обновления экрана
                        60 Гц",
                    Price = 27999M,
                    PictureFileName = "242663618.jpg",
                    LaptopBrandId = 6,
                    ScreenTypeId = 7,
                    AvailableStock = 1,
                    Sku = "586514"
                },
                new()
                {
                    Id = 13,
                    Name = "Lenovo IdeaPad 3 15IML05 (81WB011FRA) Business Black",
                    Description = @"Процессор
                        Двухъядерный Intel Pentium Gold 6405U (2.4 ГГц)
                        Операционная система
                        Без ОС
                        Диагональ экрана
                        15.6 (1920x1080) Full HD
                        Тип экрана
                        TN
                        Частота обновления экрана
                        60 Гц",
                    Price = 15299M,
                    PictureFileName = "251846125.jpg",
                    LaptopBrandId = 8,
                    ScreenTypeId = 8,
                    AvailableStock = 1,
                    Sku = "427826"
                },
                new()
                {
                    Id = 14,
                    Name = "HP EliteBook 8470P 14.0 HD Core I7 SSD 180 GB БУ",
                    Description = @"Процессор
                        Двухъядерный Intel Core i7-3520M (2.9 ГГц)
                        Операционная система
                        Windows 10 Home
                        Поколение процессора Intel
                        3-е Ivy Bridge
                        Выбор языка в предустановленной Windows
                        Диагональ экрана
                        14.1 (1366х768) WXGA HD
                        Тип экрана
                        UWVA",
                    Price = 7770M,
                    PictureFileName = "242628909.jpg",
                    LaptopBrandId = 5,
                    ScreenTypeId = 9,
                    AvailableStock = 1,
                    Sku = "327586"
                },
                new()
                {
                    Id = 15,
                    Name = "Dell Latitude 5310 (N004L531013UA_WP)",
                    Description = @"Количество слотов для оперативной памяти
                        2
                        Тип экрана
                        VA
                        Частота обновления экрана
                        60 Гц
                        Встроенная камера
                        WEB-Camera",
                    Price = 39888M,
                    PictureFileName = "227154202.jpg",
                    LaptopBrandId = 4,
                    ScreenTypeId = 10,
                    AvailableStock = 2,
                    Sku = "334944"
                },
                new()
                {
                    Id = 16,
                    Name = "Microsoft Surface Laptop Go - 12.4- Core i5 - 8 GB Ram - 256 GB SSD (THJ-00001) Platinum",
                    Description = @"Процессор
                        Двухъядерный Intel Core i7-3520M (2.9 ГГц)
                        Операционная система
                        Windows 10 Home
                        Поколение процессора Intel
                        3-е Ivy Bridge
                        Выбор языка в предустановленной Windows
                        Диагональ экрана
                        14.1 (1366х768) WXGA HD
                        Тип экрана
                        UWVA",
                    Price = 26207M,
                    PictureFileName = "9859612.jpg",
                    LaptopBrandId = 7,
                    ScreenTypeId = 2,
                    AvailableStock = 1,
                    Sku = "181185"
                }
            };
        }
    }
}
