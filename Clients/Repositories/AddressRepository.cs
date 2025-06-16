using Abstractions.IRepositories;
using Clients.Context;
using Clients.Mapper;
using Models.Dto;

namespace Clients.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BaseDbContext _dbContext;
        private readonly AddressMapper _addressMapper;

        public AddressRepository(BaseDbContext dbContext, AddressMapper addressMapper)
        {
            _dbContext = dbContext;
            _addressMapper = addressMapper;
        }

        public long AddAddress(AddressDto addressDto)
        {
            var address = _addressMapper.AddressDtoToAddress(addressDto);
            _dbContext.Add(address);
            _dbContext.SaveChanges();
            return address.Id;
        }

        public AddressDto GetAddressById(int id)
        {
            var address = _dbContext.Address.Find(id);
            return address == null ? null : _addressMapper.AddressToAddressDto(address);
        }
    }
}
