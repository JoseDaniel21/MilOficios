using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilOficios.Entidades
{
    public class Result
    {
 
        public int codResultado { get; set; }
      
        public string desResultado { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Usuario login { get; set; }
    }
}
