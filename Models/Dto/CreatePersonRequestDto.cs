namespace Models.Dto
{
    public record CreatePersonRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDto Address { get; set; } = new();
    }
}
