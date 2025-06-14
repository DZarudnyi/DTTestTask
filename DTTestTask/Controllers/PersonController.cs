using Abstractions.IServices;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;

namespace DTTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("savePerson")]
        public PersonDto SavePerson(CreatePersonRequestDto requestDto)
        {
            return _personService.SavePerson(requestDto);
        }

        [HttpGet("getPerson")]
        public PersonDto GetPerson(long id)
        {
            return _personService.GetPersonById(id);
        }

        [HttpGet("getAllPerson")]
        public List<PersonDto> GetPersons()
        {
            return _personService.GetAllPersons();
        }
    }
}
