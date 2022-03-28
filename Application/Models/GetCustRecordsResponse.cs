using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class GetCustRecordsResponse : BaseResponse<IEnumerable<User>>
    {
        public GetCustRecordsResponse(IEnumerable<User> onboard) : base(onboard) { }
        public GetCustRecordsResponse(string message) : base(message) { }
    }
}
