using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TowersApiNormal.Models
{
    public class Towers
    {
        public int tower_id { get; set; }
        public string @operator { get; set; }
        public string address { get; set; }
        public double height { get; set; }
        public string tower_type { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string technology { get; set; }
    }
}