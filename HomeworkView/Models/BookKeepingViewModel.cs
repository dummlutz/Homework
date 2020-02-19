using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkView.Models
{
    public class BookKeepingViewModel
    {
        //public int No { get; set; }
        public string ID { get; set; }
        public string Category { get; set; }

        [DataType(DataType.Currency)]
        public double Amout { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDate { get; set; }

        public string Remark { get; set; }
    }
}