namespace USSD.Models;

public class Ussd
{
    //public  Guid Id { get; set; }
    public string Id { get; set; } = $"ussd:{Guid.NewGuid().ToString()}";

    public  string sessionId { get; set; }
    public string serviceCode { get; set; }
    public  string phoneNumber { get; set; }
    public  string text { get; set; }
}