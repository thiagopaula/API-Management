using API_Management.GraphQL.Types;
using Application.Interfaces;
using GraphQL.Types;
using System;

namespace API_Management.GraphQL
{
    public class GraphQLQuery : ObjectGraphType<object>
    {
        public ICityAppService CityAppService { get; set; }
        public GraphQLQuery(GraphQLData data)
        {
            Name = "Query";

            Field<ListGraphType<CityInterface>>("hero", resolve: context => data.GetAllAsync());

            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetByIdAsync(id);

            FieldDelegate<CityType>(
                "city",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id"}
                ),
                resolve: func
            );
        }
    }
}
