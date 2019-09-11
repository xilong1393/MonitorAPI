using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class Classrecording
    {
        public int ClassRecordingID { get; set; }
        public DateTime ClassStartTime { get; set; }
        public char Status { get; set; }
        public char Uploaded { get; set; }
        public DateTime? UploadTime { get; set; }
        public string FileServerName { get; set; }
        public string ClassDataDir { get; set; }
        public string EngineVersion { get; set; }
        public int? WhiteBoardNum { get; set; }
        public int ClassID { get; set; }
        public bool? Viewable { get; set; }
        public int ClassScheduleID { get; set; }
        public int? UploadDuration { get; set; }
        public string FlashDataPath { get; set; }
        public int FlashStatus { get; set; }
        public string PodcastDataPath { get; set; }
        public string UploadXML { get; set; }
        public string RecordingName { get; set; }
        public string RecordingDescription { get; set; }


    }
}