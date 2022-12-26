using EitaaGram.BotLib.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EitaaGram.BotLib.Network
{
    internal class RequestSender
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        public RestResponse Response { get; private set; }
        public bool IsSuccess { get; private set; }
        public ErrorType ErrorDetails { get; private set; }

        private bool IsFile = false;

        public RequestSender(string url)
        {
            _client = new RestClient(url);
            _request = new RestRequest();
            RequirementOperations();
        }


        public async Task MakeRequest()
        {
            if (!IsFile)
            {
                _request.AddHeader("Content-Type", "application/json");
                _request.AddHeader("Accept", "application/json");
            }

            Response = await _client.ExecuteAsync(_request);
            var json = JObject.Parse(Response.Content);
            if (json.First.ToString().Contains("true"))
            {
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
                ErrorDetails = JsonConvert.DeserializeObject<ErrorType>(Response.Content);
            }

        }




        public RequestSender AddBody(string data)
        {
            _request.AddBody(data);
            return this;
        }

        public RequestSender AddFile(string name, string path)
        {
            _request.AddFile(name, path);
            IsFile = true;
            return this;
        }

        private void RequirementOperations()
        {
            _request.Method = Method.Post;
        }
    }
}
