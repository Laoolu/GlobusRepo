using Application.Handlers.Command;
using Application.Handlers.Queries;
using Application.Models;
using Domain.Entities;
using Domain.Repository;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Test
{
    public class UserCommandHandlerTest
    {
        private readonly Mock<IGenericRepository> _mockRepo;
        private readonly UserQuery _user;

        public UserCommandHandlerTest()
        {
            _mockRepo = MockGenericRepository.GetAllCustomerRepository();
            _user = new UserQuery
            {
                phoneNumber = "08137392922",
                email = "sam@gmail.com",
                state = "lagos",
                lga = "ikeja"
            };
        }

        [Fact]
        [Test]
        public async Task validUserAdded()
        {
            var handler = new UserCommandHandler(_mockRepo.Object);

            var result = await handler.Handle(new UserQuery()
            {
                phoneNumber = "08137392922",
                email = "sam@gmail.com",
                state = "lagos",
                lga = "ikeja"
            }, CancellationToken.None);

            result.ShouldBeOfType<UserResponse>();


        }
    }
}
