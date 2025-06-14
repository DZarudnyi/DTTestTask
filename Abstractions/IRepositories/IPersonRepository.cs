using Models.Dto;

namespace Abstractions.IRepositories
{
    public interface IPersonRepository
    {
        public PersonDto SavePerson(PersonDto person);

        public PersonDto GetPersonById(int id);

        public PersonDto GetAllPersons();
    }
}
