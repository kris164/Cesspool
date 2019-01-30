using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cesspool.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace Cesspool.Controler
{
    [Route("api/[controller]")]
    public class pessoController : Controller
    {
        DatosContext db;
        public pessoController(DatosContext _db)
        {
            db = _db;
        }

        [HttpGet("GetPesso")]
        public IActionResult GetPesso()
        {
          //  IQueryable<pesso> query = db.pesso.Take(1);

        //git clone https://github.com/kris164/Cesspool.git

        // List<pesso> dataList =  db.pesso.OrderByDescending(z=>z.Id).ToList();
        //DateTime ds = new DateTime("2018-09-25 22:06:33")
        
             DateTime value = new DateTime(2018, 9, 25,22,6,33);


       List<pesso> dataList = db.pesso.Where(z=>z.lastUpdated >= value).ToList();


       // dataList.GroupBy(i => i.lastUpdated.ToString("yyyyMMdd"))
       //      .Select(i => new
       //      {
       //          Date = DateTime.ParseExact(i.Key, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None),
       //          Count = i.Count()
       //      });

        var q= from i in dataList
        group i by i.lastUpdated.Date into g
         select new {

            lastUpdated = g.Key,
            Name = g.FirstOrDefault()  
        };





          ViewModel model = new ViewModel();
           model.Lista =  dataList;


           List<DataPoint> dataPoints = new List<DataPoint>();//{

    
                int a = 1;
                foreach (var item in q)
              {
                  double results;
                  var hel = 185 - Convert.ToInt32(item.Name.Name) + 30;
                  double.TryParse(hel.ToString(), out results);

                //var d = item.lastUpdated.AddDays(a).ToShortDateString();

                a++;

                        dataPoints.Add(new DataPoint(y:results,label:item.lastUpdated.ToShortDateString()));

                 // new DataPoint(item.lastUpdated, results),
              }


      //      dataPoints.Add(new DataPoint(y:1,x:1));
       //     dataPoints.Add(new DataPoint(y:2,x:4));
       //     dataPoints.Add(new DataPoint(y:3,x:2));


            model.dataPoints = dataPoints;

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

 
          return View(model);

        }


        


    }

      public class ViewModel
    {
        public IEnumerable<pesso> Lista { get; set; }
        public  IEnumerable<DataPoint> dataPoints { get; set; }
    }
}
