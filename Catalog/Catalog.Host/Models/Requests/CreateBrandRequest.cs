using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class CreateBrandRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;
    }
}
