using Application.Common.Behavior;
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

namespace Application.Handlers.Command
{
    public class UserCommandHandler : IRequestHandler<UserQuery, UserResponse>
    {
        private IGenericRepository _onboardRepo;

        public UserCommandHandler(IGenericRepository onboardRepo)
        {
            _onboardRepo = onboardRepo;
        }

        public async Task<UserResponse> Handle(UserQuery query, CancellationToken cancellationToken)
        {
            var rsp = new UserRsp();

           await _onboardRepo.Createuser(Mapping.Map(query));

            return new UserResponse(rsp);
        }
    }
}
