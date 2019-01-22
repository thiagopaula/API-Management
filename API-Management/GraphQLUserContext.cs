
using System.Security.Claims;


namespace API_Management
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
