using System.Text.Json;
using StackExchange.Redis;
using USSD.Contracts;
using USSD.Models;

namespace USSD.Repository;

public class UssdRepository : IUssdRepository
{
    private readonly IConnectionMultiplexer _redis;

    public UssdRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }
    
    public string proceed = "CON ";
    public string terminate = "END ";
    public void SendUssd(Ussd ussd)
    {
        var select = ussd.text;
        var response = "";
           
        switch (select)
        {
            case "":
                response = proceed + "Welcome to Mentor Sacco. Please select: \n"
                                   + "1. Login \n"
                                   + "0. Exit \n";
                break;
                
            case "0":
                response = terminate +"Thank you for using our services";
                break;  
                
            case "1":
                response = proceed +"Thank you for using our services";
                break;
        }

        if (ussd == null)
        {
            throw new ArgumentOutOfRangeException(nameof(ussd));
        }

        var db = _redis.GetDatabase();

        var s = JsonSerializer.Serialize(response);

        db.HashSet($"hashussd", new HashEntry[] 
            {new HashEntry(ussd.Id, s)});
    }
}