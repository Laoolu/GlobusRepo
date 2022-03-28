using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserResponse : BaseResponse<UserRsp>
    {
        public UserResponse(UserRsp onboardRsp) : base(onboardRsp) { }
        public UserResponse(string message) : base(message) { }
    }

    public class UserRsp
    {
        public string message { get; set; } = "record updated successfully";
    }
}
