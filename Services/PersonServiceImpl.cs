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

        public PersonServiceImpl(IPersonRepository personRepository, IAddressRepository addressRepository, PersonMapper personMapper)
        {
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _personMapper = personMapper;
        }

        public List<PersonDto> GetAllPersons()
        {
            return _personRepository.GetAllPersons();
        }

        public List<PersonDto> GetFilteredPersons(PersonDto request)
        {
            return _personRepository.GetFilteredPersons(request);
        }

        public PersonDto GetPersonById(long id)
        {
            return _personRepository.GetPersonById(id);
        }

        public PersonDto SavePerson(CreatePersonRequestDto requestDto)
        {
            long? addressId = null;
            if (requestDto.Address != null && !string.IsNullOrEmpty(requestDto.Address.City))
            {
                addressId = _addressRepository.AddAddress(requestDto.Address);
            }

            var personDto = _personMapper.RequestDtoToDto(requestDto);
            personDto.AddressId = addressId ?? 0;
            return _personRepository.SavePerson(personDto);
        }
    }
}
