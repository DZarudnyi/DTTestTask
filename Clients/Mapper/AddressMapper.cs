using Models.Dto;
using Riok.Mapperly.Abstractions;

namespace Clients.Mapper
{
    [Mapper]
    public partial class AddressMapper
    {
        public partial AddressDto AddressToAddressDto(Address address);

        public partial Address AddressDtoToAddress(AddressDto addressDto);
    }
}
