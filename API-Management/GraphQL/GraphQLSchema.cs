
using GraphQL;
using GraphQL.Types;

namespace API_Management.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver)
        : base(resolver)
        {
            Query = resolver.Resolve<GraphQLQuery>();
        }
    }
}
