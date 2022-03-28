using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Linq;

namespace GlobusBankOnboarding.Api
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OnboardingContext(
                serviceProvider.GetRequiredService<DbContextOptions<OnboardingContext>>()))
            {
                // Look for any board games.
                if (context.Onboards.Any())
                {
                    return;   // Data was already seeded
                }

                context.Onboards.AddRange(
                   new User
                   {
                       id = 1,
                       phoneNumber = "08137392922",
                       email = "sam@gmail.com",
                       state = "lagos",
                       lga = "ikeja"
                   },
                   new User
                   {
                       id = 2,
                       phoneNumber = "07022345678",
                       email = "seyi@gmail.com",
                       state = "lagos",
                       lga = "alimosho"
                   });

                context.SaveChanges();
            }
        }
    }
}