using Directions.Model;
using Directions.Utils;
using System;

namespace Directions.Services
{
    public class PrintConsoleService
    {

        public void PrintDirections(FormatInstructionUtil formatInstructionUtil, Direction direction)
        {
            Leg leg = direction.routes[0].legs[0];

            Console.WriteLine($"Route from {leg.start_address} to {leg.end_address}");
            Console.WriteLine($"{leg.distance.text} in {leg.duration.text}");

            for (int i = 0; i < leg.steps.Count; i++)
            {
                string instructions = formatInstructionUtil.FormatInstructions(leg.steps[i].html_instructions);
                Console.WriteLine($"{i + 1}. {instructions}");
            }
        }
    }
}
