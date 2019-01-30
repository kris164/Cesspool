using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cesspool.Models;

namespace Cesspool.Controler
{
    [Route("api/[controller]")]
    public class insertController : Controller
    {
        DatosContext db;
        public insertController(DatosContext _db)
        {
            db = _db;
        }

        [HttpGet("{id}/{voltage}/{temperature}")]
        public List<pesso> insert(string id, string voltage, string temperature)
        {
            IQueryable<pesso> query = db.pesso.Take(1);

            if (db.pesso.Any())
            {

                DateTime date1 = DateTime.Now;

                db.pesso.Add(new pesso { Id = 0, Name = id, voltage = voltage, lastUpdated = date1, temperature = temperature });

                db.SaveChanges();
            }
            return query.ToList();

        }


    }
}
