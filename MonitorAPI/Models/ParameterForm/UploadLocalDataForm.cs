using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.ParameterForm
{
    public class UploadLocalDataForm
    {
        public string SessionID { get; set; }
        public int ClassroomID { get; set; }

        public ArrayList Dirnames { get; set; }
    }
}