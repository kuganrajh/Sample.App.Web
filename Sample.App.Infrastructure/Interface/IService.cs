using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.App.Infrastructure.Interface
{
    public interface IService<T>
    {
        List<T> Get();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> DeleteAsync(int id);
    }
}
