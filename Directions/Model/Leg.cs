using System.Collections.Generic;


namespace Directions.Model
{
    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public string start_address { get; set; }
        public List<Step> steps { get; set; }

    }
}
