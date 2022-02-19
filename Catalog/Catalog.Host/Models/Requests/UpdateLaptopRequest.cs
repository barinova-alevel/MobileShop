using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class UpdateLaptopRequest : CreateLaptopRequest
    {
        [Required]
        public int? Id { get; set; }
    }
}
