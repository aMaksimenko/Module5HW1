using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using HomeWork.Models;
using HomeWork.Services.Interfaces;

namespace HomeWork.Services
{
    public class ResourceService<T> : IResourceService<T>
    {
        private readonly IHttpService _httpService;
        private readonly string _apiUrl;

        public ResourceService(IHttpService httpService, string apiUrl)
        {
            _httpService = httpService;
            _apiUrl = apiUrl;
        }

        public async Task<List<T>> List(int page)
        {
            var result = await _httpService.Get($"{_apiUrl}?page=${page}");
            var responseData = JsonSerializer.Deserialize<Response<List<T>>>(result);

            return responseData?.Data;
        }

        public async Task<T> Get(int id)
        {
            var result = await _httpService.Get($"{_apiUrl}/{id}");
            var responseData = JsonSerializer.Deserialize<Response<T>>(result);

            return responseData!.Data;
        }

        public async Task<T> Create(T model)
        {
            var result = await _httpService.Post(_apiUrl, model);
            var responseData = JsonSerializer.Deserialize<T>(result);

            return responseData;
        }

        public async Task<T> Update(T model)
        {
            var result = await _httpService.Put(_apiUrl, model);
            var responseData = JsonSerializer.Deserialize<T>(result);

            return responseData;
        }

        public async Task<string> Delete(int id)
        {
            var result = await _httpService.Delete($"{_apiUrl}/{id}");

            return result;
        }
    }
}