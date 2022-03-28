using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public partial class OnboardingContext : DbContext
    {
        //public OnboardingContext()
        //{
        //}

        public OnboardingContext(DbContextOptions<OnboardingContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Onboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var onboardUser = new User
            {
                id = 1,
                phoneNumber = "08137392922",
                email = "sam@gmail.com",
                state = "lagos",
                lga = "ikeja"
            };

            var onboardUser2 = new User
            {
                id = 2,
                phoneNumber = "07010293847",
                email = "dayo@gmail.com",
                state = "lagos",
                lga = "alimosho"
            };
        }
    }
}



//using (var context = new OnboardingContext(options))
//{
//    var onboardUser = new Onboard
//    {
//        id = 1,
//        phoneNumber = "08137392922",
//        email = "sam@gmail.com",
//        state = "lagos",
//        lga = "ikeja"
//    };

//    context.Onboards.Add(onboardUser);
//    context.SaveChanges();
//}