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
            Field<InfoType>(
                "addLike",
               arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<InfoInputType>> { Name = "info" },
               new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "infoId" }),
               resolve: context =>
               {
                 var info = context.GetArgument<Info>("info");
                 var infoID = context.GetArgument<string>("infoId");
                 var dbOwner = InfoRepository.GetByID(infoID);
                  return InfoRepository.UpdateInfo(infoID, info);
               });
        }
    }
}
