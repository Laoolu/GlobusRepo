using Application.Handlers.Commands;
using Application.Handlers.Queries;
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
    public class GetUserRecordsHandlerTest
    {
        private readonly Mock<IGenericRepository> _mockRepo;

        public GetUserRecordsHandlerTest()
        {
            _mockRepo = MockGenericRepository.GetAllCustomerRepository();
        }

        [Fact]
        [Test]
        public async Task GetCustomerRecords()
        {
            var handler = new GetUserRecordsCommandHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetUserRecordsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<User>>();

            result.Count.ShouldBe(2);
        }
    }

}
