using Directions.Model;
using Directions.Request;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Directions.Services
{
    public class DirectionService
    {

        private readonly IConfiguration _configuration;


        public DirectionService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public Direction GetDirections(DirectionRequest request)
        {
            string ApiKey = _configuration.GetValue<string>("Configs:ApiKey");
            string ApiUrl = _configuration.GetValue<string>("Configs:ApiUrl");

            if (string.IsNullOrEmpty(ApiUrl) && string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentException("GoogleMapsApiKey or ApiUrl is missing in appsettings.json.");
            }

           string url = $"{ApiUrl}?origin={request.OriginName}&destination={request.DestinationName}&key={ApiKey}";

           using HttpClient client = new();

           var result = client.GetStringAsync(url).Result;

           return DeserializeDirections(result);
        }

        private static Direction DeserializeDirections(string json)
        {
            return JsonConvert.DeserializeObject<Direction>(json);
        }

    }
}
