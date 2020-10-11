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
        public bool take_out { get; set; }
        public bool limit_seating { get; set; }
        public bool indoor_dining { get; set; }
        public bool curbside { get; set; }
        public string comments { get; set; }
    }
}
