using GraphQL.Client;
using GraphQL.Common.Request;
using System.Collections.Generic;

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
                          name,
                          price,
                          change
                        }
                    }"
            };
            var graphQLResponse = _client.PostAsync(request).Result;
            var news = graphQLResponse.GetDataFieldAs<List<Model.Info>>("infos");
            return news;
        }

        /*public bool? Feedback(string id, bool like)
        {
            var request = new GraphQLRequest()
            {
                Query = @"
                    mutation 
                        feedback($id: String!, $like: Boolean!) {
                            feedback(id: $id, like: $like){ 
                                iD, like
                            }
                        }",
                Variables = new { id = id, like = like }
            };
            var graphQLResponse = _client.PostAsync(request).Result;
            var news = graphQLResponse.GetDataFieldAs<Model.News>("feedback");
            return news.Like;
        }*/
    }
}
