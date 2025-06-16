using Models.Dto;

namespace Abstractions.IRepositories
{
    public interface IPersonRepository
    {
        public PersonDto SavePerson(PersonDto person);

        public PersonDto GetPersonById(long id);

        public List<PersonDto> GetAllPersons();

        public List<PersonDto> GetFilteredPersons(PersonDto request);
    }
}
