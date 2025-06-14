using Clients.Context;
using Clients.Mapper;
using Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Repositories
{
    public class AddressRepository
    {
        private readonly BaseDbContext _dbContext;
        private readonly AddressMapper _addressMapper;

        public AddressRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
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
            return _dbContext.Find();
        }
    }
}
