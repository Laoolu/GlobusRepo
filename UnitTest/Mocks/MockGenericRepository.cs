using Domain.Entities;
using Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocks
{
    public static class MockGenericRepository
    {
        public static Mock<IGenericRepository> GetAllCustomerRepository()
        {
            var custRecords = new List<User>
            {
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
                    phoneNumber = "07010293847",
                    email = "dayo@gmail.com",
                    state = "lagos",
                    lga = "alimosho"
                }

            };

            var mockRepo = new Mock<IGenericRepository>();

            mockRepo.Setup(r => r.GetAllCustomers()).ReturnsAsync(custRecords);

            mockRepo.Setup(r => r.Createuser(It.IsAny<User>())).ReturnsAsync((User onboard) =>
            {
                custRecords.Add(onboard);

                return onboard;
            });

            return mockRepo;
        }
    }
}
