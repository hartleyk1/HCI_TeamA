using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha.Models
{
    public class reviews
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public int rating { get; set; }
        public string rating_text { get; set; }
        public string review_text { get; set; }
        public string review_time_friendly { get; set; }
        public string customer_name { get; set; }
    }
}
