using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto
{
    public record AddressDto
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
