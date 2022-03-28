using Application.Handlers.Queries;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobusBankOnboarding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController : BaseController
    {
        [HttpPost("onboard-customer")]
        public async Task<UserResponse> OnboardUser([FromBody] UserQuery command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("fetch-customers-records")]
        public async Task<List<User>> Customers()
        {
            return await Mediator.Send(new GetUserRecordsQuery());
        }

        [HttpGet("fetch-gold-prices")]
        public async Task<RapidApiResponse> GoldPrices()
        {
            return await Mediator.Send(new RapidApiQuery());
        }
    }
}
