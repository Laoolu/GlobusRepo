using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IGenericRepository
    {
        Task<List<User>> GetAllCustomers();
        Task<User> Createuser(User onboard);
    }
}