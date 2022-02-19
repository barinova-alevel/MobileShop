using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class UpdateOperationSystemRequest
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;
    }
}
