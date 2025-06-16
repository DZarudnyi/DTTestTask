using Models.Dto;

namespace Abstractions.IRepositories;

public interface IAddressRepository
{
    public long AddAddress(AddressDto address);

    public AddressDto GetAddressById(int id);
}

