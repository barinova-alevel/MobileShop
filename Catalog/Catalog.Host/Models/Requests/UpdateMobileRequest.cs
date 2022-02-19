using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class UpdateMobileRequest : CreateMobileRequest
    {
        [Required]
        public int? Id { get; set; }
    }
}
