using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cesspool.Models
{
    public class pesso
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string voltage {get;set;} 

        public string temperature {get;set;}      

        public System.DateTime lastUpdated  {get;set;} 
    }
}
