using Application.Common.Interface;
using Application.Models;
using RestSharp;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class RapidApiService : IRapidApiService
    {
        public async Task<RapidApiRsp> FetchGoldPrice()
        {
            var client = new RestClient("https://gold-price-live.p.rapidapi.com/get_metal_prices");

            var request = new RestRequest();

            request.AddHeader("X-RapidAPI-Host", "gold-price-live.p.rapidapi.com");

            request.AddHeader("X-RapidAPI-Key", "8d18a9c4fdmsh1b9ec6e7b7a6314p171345jsn3c1116ad6f52");

            RestResponse<RapidApiRsp> response = await client.ExecuteAsync<RapidApiRsp>(request);

            return response.Data;
        }

    }
}
