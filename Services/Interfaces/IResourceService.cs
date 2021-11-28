using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeWork.Services.Interfaces
{
    public interface IResourceService<T>
    {
        public Task<List<T>> List(int page);
        public Task<T> Get(int id);
        public Task<T> Create(T model);
        public Task<T> Update(T model);
        public Task<string> Delete(int id);
    }
}