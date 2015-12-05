using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessibilita.Data.Entities
{
    public class Rate
    {
        public int RateID { get; set; }
        public int Rating { get; set; }
        public int AccountID { get; set; }
        public int PlaceID { get; set; }
        public int RateTypeID { get; set; }
    }
}
