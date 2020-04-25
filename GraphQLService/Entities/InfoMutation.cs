using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService.Entities
{
    public class InfoMutation : ObjectGraphType
    {
        public InfoMutation()
        {
            Field<InfoType>(
                "addInfo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<InfoInputType>> { Name = "info" }
                ),
                resolve: context =>
                {
                    var n = context.GetArgument<Info>("info");
                    return InfoRepository.AddInfo(n);
                });
        }
    }
}
