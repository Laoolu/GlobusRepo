using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RapidApiResponse : BaseResponse<RapidApiRsp>
    {
        public RapidApiResponse(RapidApiRsp rapidRsp) : base(rapidRsp) { }
        public RapidApiResponse(string message) : base(message) { }
    }

    public class RapidApiRsp
    {
        public float gold { get; set; }
        public float silver { get; set; }
        public string message { get; set; }
    }
}
