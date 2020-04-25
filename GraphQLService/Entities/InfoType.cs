using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService.Entities
{
    public class InfoType : ObjectGraphType<Info>
    {
        public InfoType()
        {
            Field(x => x.id);
            Field(x => x.name);
            Field(x => x.price);
            Field(x => x.change);
            Field(x => x.perentage_changed);
            Field(x => x.like);
        }

    }
}
