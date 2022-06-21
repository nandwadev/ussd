using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using USSD.Contracts;
using USSD.Infrastructure.abstractions;
using USSD.Request;

namespace USSD.Service
{
  public class UssdService : IUssdService
  {
    private readonly IRepositoryUnit _repository;
    private readonly HttpClient _httpClient;
    private readonly ILogger<UssdService> _logger;

    public UssdService(IRepositoryUnit repository, HttpClient httpClient,
       ILogger<UssdService> logger)
    {
      _repository = repository;
      _httpClient = httpClient;
      _logger = logger;
    }

    public async Task<HttpResponseMessage> InitiateUssdAsync(UssdRequest ussd, CancellationToken cancellationToken){
      

      var httpContent = new StringContent(JsonConvert.SerializeObject(ussd), Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync($"", httpContent);

      return response;
    }
  }
}
