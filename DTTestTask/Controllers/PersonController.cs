using Abstractions.IServices;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;

namespace DTTestTask.Controllers;

/// <summary>
/// Controller for managing persons
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    /// Creates a new person
    /// </summary>
    /// <param name="request">Data for creating a person</param>
    /// <returns>Created person</returns>
    /// <response code="200">Person successfully created</response>
    /// <response code="400">Invalid request data</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreatePerson([FromBody] CreatePersonRequestDto request)
    {
        var result = _personService.SavePerson(request);
        return Ok(result);
    }

    /// <summary>
    /// Gets a list of persons with filtering options
    /// </summary>
    /// <param name="firstName">First name for filtering</param>
    /// <param name="lastName">Last name for filtering</param>
    /// <param name="city">City for filtering</param>
    /// <returns>List of persons matching the filter criteria</returns>
    /// <response code="200">List of persons successfully retrieved</response>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<PersonDto>), StatusCodes.Status200OK)]
    public IActionResult SearchPersons(
        [FromQuery] string? firstName,
        [FromQuery] string? lastName,
        [FromQuery] string? city)
    {
        var filter = new PersonDto
        {
            FirstName = firstName,
            LastName = lastName,
            Address = new AddressDto { City = city }
        };

        var result = _personService.GetFilteredPersons(filter);
        return Ok(result);
    }

    /// <summary>
    /// Gets a person by ID
    /// </summary>
    /// <param name="id">Person ID</param>
    /// <returns>Person with the specified ID</returns>
    /// <response code="200">Person successfully found</response>
    /// <response code="404">Person not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetPersonById(long id)
    {
        var result = _personService.GetPersonById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    //[HttpGet("getAllPerson")]
    //public List<PersonDto> GetPersons()
    //{
    //    return _personService.GetAllPersons();
    //}
}

