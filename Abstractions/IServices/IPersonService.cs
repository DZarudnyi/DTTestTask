using Models.Dto;

namespace Abstractions.IServices
{
    public interface IPersonService
    {
        public PersonDto SavePerson(CreatePersonRequestDto person);
        public PersonDto GetPersonById(long id);
        public List<PersonDto> GetAllPersons();
    }
}
