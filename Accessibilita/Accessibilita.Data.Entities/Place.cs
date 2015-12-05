using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Accessibilita.Data.Entities.Enumerators;

namespace Accessibilita.Data.Entities
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string ExternalId { get; set; }
        public SourceType SourceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double AverageRating { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
