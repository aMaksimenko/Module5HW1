using System.Text.Json;
using System.Threading.Tasks;
using HomeWork.Services.Interfaces;

namespace HomeWork.Services
{
    public class RegisterService<T> : IRegisterService<T>
    {
        private readonly IHttpService _httpService;
        private readonly string _apiUrl;

        public RegisterService(IHttpService httpService, string apiUrl)
        {
            _httpService = httpService;
            _apiUrl = apiUrl;
        }

        public async Task<T> Register(object model)
        {
            var result = await _httpService.Post(_apiUrl, model);
            var responseData = JsonSerializer.Deserialize<T>(result);

            return responseData;
        }
    }
}