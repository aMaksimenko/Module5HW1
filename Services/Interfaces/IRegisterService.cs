using System.Threading.Tasks;

namespace HomeWork.Services.Interfaces
{
    public interface IRegisterService<T>
    {
        public Task<T> Register(object model);
    }
}