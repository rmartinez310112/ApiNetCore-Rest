using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrueHome.Modelo
{
    public class Activity
    {
        [Key]
        public int activity_id { get; set; }
        public DateTime schedule { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string status { get; set; }
        public int property_id { get; set; }
        public Property property { get; set; }
        public string activityGuid { get; set; }
    }
}
