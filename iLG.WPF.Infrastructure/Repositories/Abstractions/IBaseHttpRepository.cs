using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLG.WPF.Infrastructure.Repositories.Abstractions
{
    public interface IBaseHttpRepository<T> where T : class
    {
        Task<T> GetAsync(string url);
        Task<T> PostAsync(string url, T entity);
        Task<T> PutAsync(string url, T entity);
        Task DeleteAsync(string url);
    }
}
