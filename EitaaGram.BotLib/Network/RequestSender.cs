using EitaaGram.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace EitaaGram.Bot.Network
{
    internal class RequestSender
    {
        private readonly HttpClient _client;
        private StringContent _content;
        public HttpResponseMessage Response { get; private set; }
        public bool IsSuccess { get; private set; }
        public ErrorType ErrorDetails { get; private set; }

        private MultipartFormDataContent multipartFormContent;

        public RequestSender(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(url);
        }


        public async Task MakeRequest()
        {
            if (multipartFormContent is null)
            {
                Response = await _client.PostAsync(_client.BaseAddress, _content);
            }
            else
            {
                Response = await _client.PostAsync(_client.BaseAddress, multipartFormContent);
            }

            var content = await Response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            if (json.First.ToString().Contains("true"))
            {
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
                ErrorDetails = JsonConvert.DeserializeObject<ErrorType>(content);
            }

        }

        public RequestSender AddBody(string data)
        {
            _content = new StringContent(data, Encoding.UTF8, "application/json");
            return this;
        }

        public RequestSender AddFile(Dictionary<string, StringContent> stringContents, string FilePath, string FileName)
        {
            multipartFormContent = new MultipartFormDataContent();
            stringContents.ToList().ForEach(x =>
            {
                multipartFormContent.Add(x.Value, name: x.Key);
            });

            var fileStreamContent = new StreamContent(File.OpenRead(@"C:\Users\Lion\Pictures\5964a19e8fcfcadd916cce75beb99bdc.jpg"));
            multipartFormContent.Add(fileStreamContent, name: "file", fileName: FileName);
            return this;
        }

    }
}
