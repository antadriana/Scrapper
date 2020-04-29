using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLService.Entities
{
    public class InfoQuery : ObjectGraphType
    {
     
      public InfoQuery()
        {
          

           Field<ListGraphType<InfoType>>( "infos" , resolve: context => InfoRepository.GetAll());


            Field<InfoType>( "info" ,
                      arguments: new QueryArguments(new QueryArgument < IdGraphType > { Name = "name" }),
                      resolve: context =>
        {
            var name = context.GetArgument<string>( "name" );
            return InfoRepository.GetAll().FirstOrDefault(x => x.name == name);
        });
          }

         
    }
}
