using Abstractions.IRepositories;
using Clients.Context;
using Clients.Mapper;
using Microsoft.EntityFrameworkCore;
using Models.Dto;

namespace Clients.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BaseDbContext _dbContext;
        private readonly PersonMapper _personMapper;

        public PersonRepository(BaseDbContext dbContext, PersonMapper personMapper)
        {
            _dbContext = dbContext;
            _personMapper = personMapper;
        }

        public PersonDto SavePerson(PersonDto personDto)
        {
            var person = _personMapper.PersonDtoToPerson(personDto);

            if (person.Id == 0)
            {
                _dbContext.Person.Add(person);
            }
            else
            {
                _dbContext.Person.Update(person);
            }
            _dbContext.SaveChanges();
            return _personMapper.PersonToPersonDto(person);
        }

        public PersonDto GetPersonById(long id)
        {
            var person = _dbContext.Person.Include(p => p.Address).FirstOrDefault(p => p.Id == id);
            return person == null ? null : _personMapper.PersonToPersonDto(person);
        }

        public List<PersonDto> GetAllPersons()
        {
            var persons = _dbContext.Person.Include(p => p.Address).ToList();
            return _personMapper.ToDtoList(persons);
        }

        public List<PersonDto> GetFilteredPersons(PersonDto request)
        {
            var query = _dbContext.Person
                .Include(p => p.Address)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.FirstName))
                query = query.Where(p => p.FirstName.Contains(request.FirstName));

            if (!string.IsNullOrEmpty(request.LastName))
                query = query.Where(p => p.LastName.Contains(request.LastName));

            if (!string.IsNullOrEmpty(request.Address?.City))
                query = query.Where(p => p.Address != null && p.Address.City.Contains(request.Address.City));

            return _personMapper.ToDtoList(query.ToList());
        }
    }
}
