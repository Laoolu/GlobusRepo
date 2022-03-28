using Application.Common.Interface;
using Application.Handlers.Queries;
using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class RapidApiCommandHandler : IRequestHandler<RapidApiQuery, RapidApiResponse>
    {
        private readonly IRapidApiService _rapidApiService;

        public RapidApiCommandHandler(IRapidApiService rapidApiService) => (_rapidApiService) = (rapidApiService);

        public async Task<RapidApiResponse> Handle(RapidApiQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var rsp = await _rapidApiService.FetchGoldPrice();

                return new RapidApiResponse(rsp);
            }
            catch (Exception ex)
            {
                return new RapidApiResponse(ex.Message);
            }
        }
    }
}
