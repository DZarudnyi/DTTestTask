using Models.Dto;
using Riok.Mapperly.Abstractions;

namespace Clients.Mapper
{
    [Mapper]
    public partial class PersonMapper
    {
        public partial PersonDto PersonToPersonDto(Person person);
        public partial List<PersonDto> ToDtoList(List<Person> persons);
        public partial Person PersonDtoToPerson(PersonDto personDto);        
        public partial Person PersonDtoToPerson(CreatePersonRequestDto personDto);    
        public partial PersonDto RequestDtoToDto(CreatePersonRequestDto requestDto);
    }
}
