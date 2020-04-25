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
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("price");
            Field<StringGraphType>("percent");
            Field<StringGraphType>("perentage_changed");
        }
    }
}
