using System.ComponentModel.DataAnnotations;

namespace Clients
{
    public class Address
    {
        public long Id { get; set; }
        [StringLength(4000, MinimumLength = 1)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [StringLength(4000, MinimumLength = 1)]
        [Required(ErrorMessage = "AddressLine is required")]
        public string AddressLine { get; set; }
    }
}
