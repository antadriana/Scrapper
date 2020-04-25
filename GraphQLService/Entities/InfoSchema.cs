using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService.Entities
{
    public class InfoSchema : Schema
    {
        public InfoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<InfoQuery>();
            Mutation = resolver.Resolve<InfoMutation>();
        }
    }
}
