using Application.Handlers.Queries;
using Application.Models;
using Domain.Entities;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class GetUserRecordsCommandHandler : IRequestHandler<GetUserRecordsQuery, List<User>>
    {
        private IGenericRepository _onboardRepo;

        public GetUserRecordsCommandHandler(IGenericRepository onboardRepo)
        {
            _onboardRepo = onboardRepo;
        }

        public async Task<List<User>> Handle(GetUserRecordsQuery query, CancellationToken cancellationToken)
        {
            var response = new List<User>()
          {
               new User
                 {
                    id = 1,
                    phoneNumber = "08137392922",
                    email = "sam@gmail.com",
                    state = "lagos",
                    lga = "ikeja"
                 }
          };

           var rsp = await _onboardRepo.GetAllCustomers();

            if (rsp.Count == 0)
                return response;

            return rsp;
        }
    }
}

//if (rsp.Count == 0)
//    return new GetCustRecordsResponse("No record found");

//return new GetCustRecordsResponse(rsp);