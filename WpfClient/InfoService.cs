using GraphQL.Client;
using GraphQL.Common.Request;
using System.Collections.Generic;
using WpfClient.Model;

namespace WpfClient
{
    public class InfoService
    {
        protected readonly GraphQLClient _client;
        private readonly string _url = "https://localhost:44339/api/main";

        public InfoService()
        {
            _client = new GraphQLClient(_url);
        }

        public List<Model.Info> GetAllInfos()
        {
            var request = new GraphQLRequest()
            {
                Query = @"
                    query { 
                        infos { 
                          id,
                          name,
                          price,
                          change,
                          perentage_changed,
                          like
                         
                        }
                    }"
            };
            var graphQLResponse = _client.PostAsync(request).Result;
            var news = graphQLResponse.GetDataFieldAs<List<Model.Info>>("infos");
            return news;
        }

        public bool Feedback(Info inf, bool like)
        {
            string idd = inf.id;
            inf.like = like;
            var request = new GraphQLRequest()
            {
                Query = @"
                    mutation ($info: InfoInput!, $infoId:ID!)
                      {
                        addLike(info:$info, infoId:$infoId)
                            { 
                               name                            }
                        }",
                Variables = new { info = inf, infoId = idd }
            };
                var graphQLResponse = _client.PostAsync(request).Result;
            var infoo = graphQLResponse.GetDataFieldAs<Model.Info>("addLike");
            return infoo.like;
        }
    }
}
