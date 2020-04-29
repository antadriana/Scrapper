using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService.Entities
{
    public class InfoInputType : InputObjectGraphType
    {
        public InfoInputType()
        {
            Name = "InfoInput";
            Field<NonNullGraphType<StringGraphType>>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("price");
            Field<StringGraphType>("change");
            Field<StringGraphType>("perentage_changed");
            Field<BooleanGraphType>("like");
        }
    }
}
