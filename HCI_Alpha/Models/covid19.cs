using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Models
{
    public class covid19
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public int take_out { get; set; }
        public int limit_seating { get; set; }
        public int indoor_dining { get; set; }
        public int curbside { get; set; }
        public string comments { get; set; }
    }
}
