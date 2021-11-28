using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HomeWork.Services.Interfaces;

namespace HomeWork.Services
{
    public class HttpService : IHttpService
    {
        private readonly string _baseUrl;

        public HttpService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<string> Post(string url, object payload)
        {
            var result = await HandleRequest(url, HttpMethod.Post, payload);

            return result;
        }

        public async Task<string> Get(string url)
        {
            var result = await HandleRequest(url, HttpMethod.Get);

            return result;
        }

        public async Task<string> Put(string url, object payload)
        {
            var result = await HandleRequest(url, HttpMethod.Put, payload);

            return result;
        }

        public async Task<string> Delete(string url)
        {
            var result = await HandleRequest(url, HttpMethod.Delete);

            return result;
        }

        private async Task<string> HandleRequest(string url, HttpMethod httpMethod, object payload = null)
        {
            using (var httpClient = new HttpClient())
            {
                var httpMessage = new HttpRequestMessage();

                if (payload != null)
                {
                    httpMessage.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                }

                httpMessage.RequestUri = new Uri(@$"{_baseUrl}{url}");
                httpMessage.Method = httpMethod;

                var response = await httpClient.SendAsync(httpMessage);

                if (
                    response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Created)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return "No content";
                }
                else
                {
                    throw new AggregateException(
                        $"Error during ${httpMethod} to {_baseUrl}{url} with status {response.StatusCode}");
                }
            }
        }
    }
}