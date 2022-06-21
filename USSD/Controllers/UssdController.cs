using MediatR;
using Microsoft.AspNetCore.Mvc;
using USSD.Command;
using USSD.Contracts;
using USSD.Models;
using USSD.Request;

namespace USSD.Controllers;
[ApiController]
[Route("api/v1")]
public class UssdController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUssdRepository _repository;

    public UssdController(IMediator mediator, IUssdRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }
    [HttpPost("ussd")]
  //  [Produces("application/json")]
    public async Task<ActionResult<string>> UssdRequest()
    {
            
        UssdRequest ussdRequest = new UssdRequest
        {
            sessionId = HttpContext.Request.Form["sessionId"],
            serviceCode = HttpContext.Request.Form["serviceCode"],
            phoneNumber = HttpContext.Request.Form["phoneNumber"],
            text = HttpContext.Request.Form["text"]
        };
        var response = await _mediator.Send(new UssdCommand(ussdRequest));


        return Ok(response.Data);
    }
  
  [HttpPost("redis-ussd")]
  public ActionResult <Ussd> CreatePlatform(Ussd ussd)
  {
      ussd = new Ussd
      {
          //Id = null,
          sessionId = HttpContext.Request.Form["sessionId"],
          serviceCode = HttpContext.Request.Form["serviceCode"],
          phoneNumber = HttpContext.Request.Form["phoneNumber"],
          text = HttpContext.Request.Form["text"]
      };

      _repository.SendUssd(ussd);

      return Ok(ussd);
  }
    

}
    