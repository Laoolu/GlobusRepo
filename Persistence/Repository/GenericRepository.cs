using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IDbContextFactory<OnboardingContext> _dbContextFactory;

        public GenericRepository(IDbContextFactory<OnboardingContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var _applicationDbContext =_dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database.EnsureCreated();
            }
        }

        public async Task<List<User>> GetAllCustomers()
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                return await applicationDbContext.Onboards.ToListAsync();
            }
        }
      
        public async Task<User> Createuser(User onboard)
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                await applicationDbContext.Onboards.AddAsync(onboard);
                await applicationDbContext.SaveChangesAsync();
                return onboard;
            }
        }
    }
}