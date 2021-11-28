using System.Threading.Tasks;

namespace HomeWork.Services.Interfaces
{
    public interface IHttpService
    {
        public Task<string> Post(string url, object payload);
        public Task<string> Get(string url);
        public Task<string> Put(string url, object payload);
        public Task<string> Delete(string url);
    }
}