using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class CreateLaptopRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(1000)]
        public string Description { get; set; } = null!;
        
        [Required]
        public decimal? Price { get; set; }

        public string PictureFileName { get; set; } = null!;
        
        [Required]
        public int? BrandId { get; set; }
        
        [Required]
        public int? ScreenTypeId { get; set; }

        public int AvailableStock { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Sku { get; set; } = null!;
    }
}
