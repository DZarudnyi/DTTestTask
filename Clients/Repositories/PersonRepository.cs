using Clients.Context;
using Clients.Mapper;
using Abstractions.IRepositories;
using Models.Dto;

namespace Clients.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BaseDbContext _dbContext;
        private readonly PersonMapper _personMapper;

        public PersonRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PersonDto SavePerson(PersonDto personDto)
        {
            var person = _personMapper.PersonDtoToPerson(personDto);
            _dbContext.Add(person);
            _dbContext.SaveChanges();
            return _personMapper.PersonToPersonDto(person);
        }

        public PersonDto GetPersonById(long id)
        {
            return _personMapper.PersonToPersonDto(_dbContext.Person.Find(id));
        }

        public List<PersonDto> GetAllPersons()
        {
            return _personMapper.ToDtoList(_dbContext.Person.ToList());
        }

        //public Person GetPersonById(long id)
        //{
        //    return _dbContext.Person.Find(id);
        //}              
    }
}
