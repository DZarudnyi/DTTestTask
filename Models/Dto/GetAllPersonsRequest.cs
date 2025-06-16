namespace Models.Dto
{
    public record GetAllPersonsRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
