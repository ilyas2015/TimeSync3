using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeSync3.Models
{
    public class TimePickerModel
    {
        [Required, Range(typeof(DateTime), "01/01/2017 10:00:00", "01/01/2027 12:00:00", ErrorMessage = "Selected Time not in Range")]
        public string time { get; set; }
    }
}