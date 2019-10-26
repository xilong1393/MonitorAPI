using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Models.OperationModel
{
    public class ClassSchedule
    {
        public int ClassScheduleID
        {
            get;set;
        }

        public int ClassID
        {
            get;set;
        }

        public string ClassName
        {
            get; set;
        }

        public bool IsPeriodicCourse
        {
            get; set;
        }

        public System.DateTime ClassStartTime
        {
            get; set;
        }

        public int ClassLength
        {
            get; set;
        }

        public System.Nullable<System.DateTime> ClassStartDate
        {
            get; set;
        }

        public System.Nullable<System.DateTime> ClassEndDate
        {
            get; set;
        }

        public int FileServerID
        {
            get; set;
        }

        public string ClassDataDir
        {
            get; set;
        }

        public char Status
        {
            get; set;
        }

        public int ClassTypeID
        {
            get; set;
        }

        public System.Nullable<int> WeekDayID
        {
            get; set;
        }

        public int ClassroomID
        {
            get; set;
        }

        public string InstructorName
        {
            get; set;
        }

        public int QuarterID
        {
            get; set;
        }

        public bool IsPostDelay
        {
            get; set;
        }

        public bool IsPodcast
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
    }

    public class DDatePeriod
    {
        private DateTime _StartDate;

        private DateTime _EndDate;

        public DDatePeriod()
        {
        }

        public DateTime StartDate
        {
            get { return this._StartDate; }
            set { this._StartDate = value; }
        }

        public DateTime EndDate
        {
            get { return this._EndDate; }
            set { this._EndDate = value; }
        }
    }
}