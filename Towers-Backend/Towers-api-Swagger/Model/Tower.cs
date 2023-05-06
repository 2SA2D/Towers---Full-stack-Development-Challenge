using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Towers_api.Model
{
    // define tower class
    public class Tower
    {
        //define tower_id with getter and setter
        public int tower_id { set; get; }
        
        //define @operator with getter and setter
        public string? @operator { set; get; }
        
        //define address with getter and setter
        public string? address { set; get; }
       
        //define height with getter and setter
        public double height { set; get; }
        
        //define tower_type with getter and setter
        public string? tower_type { set; get; }
        
        //define latitude with getter and setter
        public double latitude { set; get; }
       
        //define longitude with getter and setter
        public double longitude { set; get; }
        
        //define technology with getter and setter

        public string? technology { set; get; }
        
    }
}
