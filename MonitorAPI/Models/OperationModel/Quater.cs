using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class Quater
    {
        public int QuarterID { get; set; }
        public int Year { get; set; }
        public byte Quarter { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string TermCode { get; set; }
        public string YearTerm { get; set; }

        public string PS_QuarterID { get; set; }
        public string QuarterDesc { get; set; }
    }
}