using Application.Handlers.Queries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behavior
{
    public class Mapping
    {
        public static User Map(UserQuery query)
        {
            var mapping = new User
            {
                phoneNumber = query.phoneNumber,
                email = query.email,
                state = query.state,
                lga = query.lga
            };

            return mapping;
        }
    }
}
