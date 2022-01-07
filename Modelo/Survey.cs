using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrueHome.Modelo
{
    public class Survey
    {
        [Key]
        public int survey_id { get; set; }
        public string answer { get; set; }
        public DateTime created_at { get; set; }

        public int activity_id { get; set; }
        public Activity activity { get; set; }

        public string surveyGuid { get; set; }
    }
}
