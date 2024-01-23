using Directions.Model;
using Directions.Request;
using Directions.Services;
using Directions.Utils;
using Microsoft.Extensions.Configuration;

namespace Directions
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            DirectionService directionService = new DirectionService(configuration);

            DirectionRequest request = new()
            {
                DestinationName = "oslo",
                OriginName = "drammen"
            };

            Direction direction = directionService.GetDirections(request);

            PrintConsoleService printConsoleService = new();
            FormatInstructionUtil formatInstructionUtil = new();

            printConsoleService.PrintDirections(formatInstructionUtil, direction);
         
        }
    }
}
