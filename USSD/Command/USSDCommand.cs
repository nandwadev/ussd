using MediatR;
using USSD.Request;
using USSD.Wrapper;

namespace USSD.Command{

    public class UssdCommand : IRequest<Result<string>>
    {
        public UssdRequest UssdRequest { get; set; }

        public UssdCommand(UssdRequest ussdRequest)
        {
            UssdRequest = ussdRequest;
        }
    }

    internal sealed class UssdCommandHandler : IRequestHandler<UssdCommand, Result<string>>
    {
        public string proceed = "CON ";
        public string terminate = "END ";
        
        public async Task<Result<string>> Handle(UssdCommand request, CancellationToken cancellationToken)
        {
            var select = request.UssdRequest.text;
            var response = "";
           
            switch (select)
            {
                case "":
                    response = proceed + "Welcome to Mentor Sacco.\n"
                                               + "1. Login \n"
                                               + "0. Exit \n";
                    break;
                
                case "0":
                    response = terminate +"Thank you for using our services";
                    break;  
                
                case "1":
                    response = proceed +"Enter Your PIN";
                    break;
            }

            return await Result<string>.SuccessAsync(response);
        }
    }
    
}
