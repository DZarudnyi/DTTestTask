using Abstractions.IRepositories;
using Abstractions.IServices;
using Clients.Mapper;
using Models.Dto;

namespace Services
{
    public class PersonServiceImpl : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly PersonMapper _personMapper;

        public List<PersonDto> GetAllPersons()
        {
            return _personRepository.GetAllPersons();
        }

        public PersonDto GetPersonById(long id)
        {
            return _personRepository.GetPersonById(id);
        }

        public PersonDto SavePerson(CreatePersonRequestDto requestDto)
        {
            long addressId = _addressRepository.AddAddress(requestDto.Address);
            var personDto = _personMapper.RequestDtoToDto(requestDto);
            _personRepository.SavePerson(personDto);
            return personDto;
        }
    }
}
