using System;
using System.Collections;
using System.Data;

namespace MonitorAPI.Service.Operations
{
    public class FConvertToDatatable
    {
        private FConvertToDatatable()
        {
        }
        static public System.Data.DataTable ConvertRecordingToDataTable(ArrayList recordingList)
        {
            System.Data.DataTable dtRecording = new System.Data.DataTable("Recording");
            dtRecording.Columns.Add("ClassID", typeof(String));
            dtRecording.Columns.Add("ClassName", typeof(String));
            dtRecording.Columns.Add("ClassStartTime", typeof(DateTime));

            if (recordingList != null)
            {
                string sClassName, sClassID;
                DateTime dtClassStartTime;
                try
                {
                    foreach (String de in recordingList)
                    {
                        string[] sublist = de.Split('#');
                        string name = sublist[0];
                        string[] time = sublist[1].Split(' ');
                        sublist = sublist[0].Split('-');
                        sClassID = sublist[sublist.Length - 1];
                        sClassName = name.Substring(0, name.Length - sClassID.Length - 1);
                        dtClassStartTime = new DateTime(Convert.ToInt32(time[2]),
                            Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[3]),
                            Convert.ToInt32(time[4]), Convert.ToInt32(time[5]));

                        DataRow workRow = dtRecording.NewRow();
                        workRow[0] = sClassID;
                        workRow[1] = sClassName;
                        workRow[2] = dtClassStartTime;
                        dtRecording.Rows.Add(workRow);
                    }
                }
                catch (Exception)
                {
                }
            }
            return dtRecording;
        }
        //Only hashtable orgnization like CourseSchedule are accepted!
        static public System.Data.DataTable ConvertScheduleToDataTable(Hashtable CourseSchedule)
        {
            string CourseId = "", time = "", CourseName = "", length = "", chopLength = "", FTPHost = "", dtTemp = "ScheduleShow";
            System.Data.DataTable dtScheduleShow = new System.Data.DataTable(dtTemp);
            dtScheduleShow.Columns.Add("ClassID", typeof(Int32));
            dtScheduleShow.Columns.Add("ClassName", typeof(String));
            dtScheduleShow.Columns.Add("ClassStartTime", typeof(String));
            dtScheduleShow.Columns.Add("ClassLength", typeof(Int32));
            dtScheduleShow.Columns.Add("FileServerName", typeof(String));

            if (CourseSchedule != null)
            {
                try
                {
                    Hashtable ReversedCourseSchedule = ReverseHashTableKeysAndValue(CourseSchedule);
                    CourseRecordInfoCompare cc = new CourseRecordInfoCompare();
                    SortedList slCourseSchedule = new SortedList(ReversedCourseSchedule, cc);

                    foreach (DictionaryEntry de in slCourseSchedule)
                    {
                        CourseRecordInfo cri = (CourseRecordInfo)de.Key;
                        time = cri.datetimeStartTime.ToString();
                        length = cri.intLength.ToString();

                        CourseInfo cikey = (CourseInfo)de.Value;
                        CourseId = cikey.intCourseId.ToString();
                        CourseName = cikey.strCourseName;
                        chopLength = cikey.intChop_length.ToString();
                        FTPHost = cikey.strFTPHost;

                        DataRow workRow = dtScheduleShow.NewRow();
                        workRow[0] = CourseId;
                        workRow[1] = CourseName;
                        workRow[2] = time;
                        workRow[3] = length;
                        workRow[4] = FTPHost;

                        dtScheduleShow.Rows.Add(workRow);
                    }
                }
                catch (Exception)
                {
                }
            }
            return dtScheduleShow;
        }
        static public Hashtable ReverseHashTableKeysAndValue(Hashtable inputCourseSchedule)
        {
            System.Collections.Hashtable reversedhashtable = new System.Collections.Hashtable();
            foreach (CourseInfo cinfo in inputCourseSchedule.Keys)
            {
                ArrayList recordinfoarray = (ArrayList)inputCourseSchedule[cinfo];
                System.Collections.IEnumerator recordinfoenum = recordinfoarray.GetEnumerator();
                while (recordinfoenum.MoveNext())
                {
                    CourseRecordInfo rinfo = (CourseRecordInfo)recordinfoenum.Current;
                    if (!reversedhashtable.Contains(rinfo))
                    {
                        reversedhashtable.Add(rinfo, cinfo);
                    }
                }
            }
            return reversedhashtable;
        }
    }
}