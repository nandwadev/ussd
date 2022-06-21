using USSD.Models;

namespace USSD.Contracts;

public interface IUssdRepository
{
    void SendUssd(Ussd ussd);
}