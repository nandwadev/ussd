using System.Net;

namespace USSD.Wrapper
{
  public interface IResult
  {
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }
    HttpStatusCode StatusCode { get; set; }
  }

  public interface IResult<out T> : IResult
  {
    T Data { get; }
  }
}
