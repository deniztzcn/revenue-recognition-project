namespace RevenueRecognition.Models.Responses;

public class CompanyClientResponseDto
{
    public required int ClientId { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string CompanyName { get; set; }
    public required string KRS { get; set; }
}