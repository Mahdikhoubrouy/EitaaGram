using EitaaGram.BotLib.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EitaaGram.BotLib.Network
{
    internal class RequestSender
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        public RestResponse Response { get; private set; }
        public bool IsSuccess { get; private set; }
        public ErrorModel ErrorDetails { get; private set; }

        public RequestSender(string url)
        {
            _client = new RestClient(url);
            _request = new RestRequest();
            RequirementOperations();
        }


        public async Task MakeRequest()
        {
            Response = await _client.ExecuteAsync(_request);

            var json = JObject.Parse(Response.Content);

            if (json.First.ToString() == "true")
                IsSuccess = true;
            else
                IsSuccess = false;

        }


        public RequestSender AddBody(string data)
        {
            _request.AddBody(data);
            return this;
        }

        private void RequirementOperations()
        {
            _request.Method = Method.Post;
            _request.AddHeader("Content-Type", "application/json");
            _request.AddHeader("Accept", "application/json");
        }
    }
}
