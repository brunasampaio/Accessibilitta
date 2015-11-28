using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessibilita.Data.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public Account User { get; set; }
        public Place Place { get; set; }
    }
}
