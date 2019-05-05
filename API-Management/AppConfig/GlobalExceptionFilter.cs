using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Management.AppConfig
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //TODO: log aqui


        }
    }
}
