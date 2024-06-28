namespace RevenueRecognition.Models.Responses;

public class IndividualClientResponseDto
{
    public required int ClientId { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PESEL { get; set; }
}