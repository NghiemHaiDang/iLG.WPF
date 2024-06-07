using iLG.WPF.Infrastructure.Entities;
using iLG.WPF.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLG.WPF.Infrastructure.Repositories
{
    public class UserRepository : IBaseHttpRepository<User>
    {
        public Task DeleteAsync(string url)
        {
            throw new NotImplementedException();
        }

        Task<User> IBaseHttpRepository<User>.GetAsync(string url)
        {
            throw new NotImplementedException();
        }

        Task<User> IBaseHttpRepository<User>.PostAsync(string url, User entity)
        {
            throw new NotImplementedException();
        }

        Task<User> IBaseHttpRepository<User>.PutAsync(string url, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
