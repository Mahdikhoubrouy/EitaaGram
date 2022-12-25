using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Network
{
    public class RequestSender
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public RequestSender(string url)
        {
            _client = new RestClient(url);
            _request = new RestRequest();
        }



        private void RequirementOperations()
        {
            _request.AddHeader("Content-Type", "application/json");
            _request.AddHeader("Accept", "application/json");
        }
    }
}
