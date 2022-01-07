using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrueHome.Modelo
{
    public class Property
    {
        [Key]
        public int property_id { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public DateTime create_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? disabled_at { get; set; }
        public string status { get; set; }

        public string propertyGuid { get; set; }
    }
}
