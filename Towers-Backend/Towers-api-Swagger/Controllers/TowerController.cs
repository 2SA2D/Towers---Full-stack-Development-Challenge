using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Towers_api.Model;
using static System.Net.WebRequestMethods;
using System.Net;
using Microsoft.AspNetCore.Cors;

namespace Towers_api.Controllers
{
    // define the controller url
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TowerController : ControllerBase
    {
        // create towers list
        static List<Tower> towers_ = new List<Tower>()
        {
            // Add some data to the list
         new Tower { tower_id=17191, @operator="AT&T", address="W550 EUSTACE ROAD   (94421)",height=76.2,tower_type="GTOWER",latitude=45.71055556,longitude=-87.34727778,technology="5G"},
         new Tower { tower_id=41475, @operator="AT&T", address="147TH 90 ROAD (102999)",height=106.4,tower_type="GTOWER",latitude=44.77055556,longitude=-73.61305556,technology="3G"},
         new Tower { tower_id=16947, @operator="AT&T", address="28859 460th Ave (110310)",height=96,tower_type="GTOWER",latitude=44.06858333,longitude=-95.1615,technology="4G"},
         new Tower { tower_id=7634, @operator="Verizon", address="(Media One Rookery site)301 TOWER RD",height=77.1,tower_type="TOWER",latitude= 26.05313889,longitude= -81.70091667,technology="2G"},
         new Tower { tower_id=30936, @operator="AT&T", address="11000 Old Agnes Road  (55397)",height=102.1,tower_type="GTOWER",latitude=32.97641667,longitude=-97.78802778,technology="4G"},
         new Tower { tower_id=30936, @operator="AT&T", address="M626 ELM ROAD (96900)",height=93.6,tower_type="GTOWER",latitude=44.72772222,longitude=-90.08430556,technology="2G"},
         new Tower { tower_id=3203, @operator="AT&T", address="27.4 KM WNW   (94082)",height=44.5,tower_type="LTOWER",latitude=55.81572222,longitude=-132.6852778,technology="2G"}
         };
        

        // define Post Controller to add data
        //Add
        [HttpPost]
        public JsonResult AddData(Tower tower)
        {

            // add data to list
            towers_.Add(tower);
            // return data as a json result
            return new JsonResult(Ok(tower));
        }

        //find data by tower_id
        //Get
        [HttpGet]
        [EnableCors("MyPolicy")]
        public JsonResult id(int id)
        {
            // define lambda expression to fliter data
            var result = towers_.Where(x => x.tower_id == id).FirstOrDefault();
            // check if its null
            if (result == null)
            {
                // return not found 
                return new JsonResult(NotFound());
            }
            // return data as json result
            return new JsonResult(Ok(result));
        }

        // find data by multiple parameters
        //Get 
        [HttpGet]
        public JsonResult find(string networkoperator, string technology, string address)
        {
            // define lambda expression to fliter data
            var result = towers_.Where(x => (x.@operator == networkoperator) || (x.technology == technology) || (x.address == address)).FirstOrDefault();
            // check if its null
            if (result == null)
            {
                // return not found 
                return new JsonResult(NotFound());
            }
            // return data as json result
            return new JsonResult(Ok(result));
        }

        //Get All data
        [HttpGet]
        public JsonResult GetAll()
        {
            // return 
            return new JsonResult(Ok(towers_));
        }

    }

}
