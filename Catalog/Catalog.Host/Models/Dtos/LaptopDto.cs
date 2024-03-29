﻿namespace Catalog.Host.Models.Dtos
{
    public class LaptopDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = null!;

        public LaptopBrandDto LaptopBrand { get; set; } = null!;

        public LaptopScreenTypeDto ScreenType { get; set; } = null!;

        public int AvailableStock { get; set; }
        public string Sku { get; set; } = null!;
    }
}
