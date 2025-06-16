using System.ComponentModel.DataAnnotations;

namespace Clients
{
    public class Person
    {
        public long Id { get; set; }
        [StringLength(4000, MinimumLength = 1)]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [StringLength(4000, MinimumLength = 1)]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public long? AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
