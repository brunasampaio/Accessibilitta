using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessibilitta.Data.Entities
{
    public class Tip
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Account User { get; set; }
        public Place Place { get; set; }        
    }
}
