using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class CreateMobileRequest
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
        public int? OperationSystemId { get; set; }

        public int AvailableStock { get; set; }
    }
}
