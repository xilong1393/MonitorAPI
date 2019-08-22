using System;
using System.Collections;

namespace MonitorAPI.Service.Operations
{
    public enum GroupCommandType
    {
        QuerySchedule = 0,
        PushSchedule = 1,
        UpdateConfig = 2,
        RebootPPC = 3
    }

    public class CommandParameter
    {
        public string ip;
        public int port;
        public bool succ;
        public Object obj;
        public string error;
        public CommandParameter()
        {
            succ = false;
            obj = null;
        }
    };

    public enum CompareCondition
    {
        GREATE = 0,
        EQUI,
        LESS
    }
    public struct SearchCondition
    {
        public bool coursenamefilter;
        public string coursename;

        public bool datefilter;
        public CompareCondition datecomparecondition;
        public DateTime datevalue;
    }
    public struct CourseData
    {
        public int id;
        public string name;
        public DateTime datetime;
        public string directory;
    }
    public enum ClassRoomStatus
    {
        NOTGETYET = 0,
        GETTING,
        IDLE,
        RECORDING,
        WAITING,
        PROCESSING,
        DELETTING,
        UPLOADING,
        ERROR,
        UNKNOWN
    }
    public enum CourseStatus
    {
        IDLE = 0,
        RECORDING
    }
    //status id came from class room PPC and IPC
    public enum COLEngineStatus
    {
        COLENGINE_IDLE = 0,		// colengine is idle
        COLENGINE_RECORDING,		// colengine is recording lecture
        COLENGINE_PROCESSING,		// colengine is processing data
        COLENGINE_UPLOADING,		// colengine is uploading data
        COLENGINE_WAITINGPENDING,	// colengine is waiting for pending jobs
        COLENGINE_ONESTEPPROCESSING, // colengine is processing data manually
        COLENGINE_WAITINGUPLOAD,	 // colengine is waiting for upload
        COLENGINE_DELETINGDATA,		// colengine is deleting local data
        COLENGINE_NORESPONSE
    }

    public enum COLAgentStatus
    {
        COLAGENT_IDLE = 0,
        COLAGENT_RECORDING,
        COLAGENT_ERROR,
        COLAGENT_DISABLED,
        COLAGENT_NORESPONSE
    }

    public enum AVCaptureStatus
    {
        AVCapture_NoResponse = 0,	// no response from AVCapture
        AVCapture_Idle,			// AVCapture is idle
        AVCapture_Initialized,	// AVCapture is initialized and capturing still image
        AVCapture_Running,		// AVCapture is recording course video
        AVCapture_UnKnown		// Unknown status
    }

    public enum CameraStatus
    {
        Camera_Off = 0,	// camera is off
        Camera_On,	// camera is on
        Camera_UnKnown
    }

    public enum WBCaptureStatus
    {
        WBCapture_NoResponse = 0,	 // no response from wb capture
        WBCapture_Initialized,		// wb capture is initialized
        WBCapture_Ready,			// wb capture is ready to start recording
        WBCapture_Recording,	// wb capture is running
        WBCapture_FailInit,		// wb capture failed to initialize
        WBCapture_FailStart,	// wb capture failed to start recording
        WBCapture_Created,		// wb capture just created
        WBCapture_Paused,		// recording is put on hold
        WBCapture_UnKnown
    }
    public enum SoundGrabStatus
    {
        SoundGrab_NoResponse = 0, // no response from sound grab
        SoundGrab_Idle,		// sound grab is idle
        SoundGrab_Running,	// sound grab is running
        SoundGrab_Error,	// sound grab has error
        SoundGrab_UnKnown
    }
    public enum SoundDetectStatus
    {
        SoundDetect_NoResponse = 0,	// no response from
        SoundDetect_Idle,		// sound detect is idle
        SoundDetect_Running,	// sound detect is running
        SoundDetect_Error,		// sound detect has error
        SoundDetect_UnKnown
    }
    public enum SoundSourceStatus
    {
        Sound_Connected = 0,								// sound source is connected
        Must_Be_Connection_Error,						// sound source is disconnected
        Could_Be_Mixer_Problem,							//
        Could_Be_Mixer_Volume_Too_Low,					//
        Could_Be_Connection_Problem,					//
        Could_Be_Mixer_Problem_Or_Connection_Problem,	//
        Grab_Error,
        Error_Low_Volume,								// volume of sound source is too low, error message
        Warning_Low_Volume,								// volume of sound source is low, warning message
        Unknown_Problem,									//
        SoundSource_UnKnown,
    }

    public struct CourseInfo
    {
        public int intCourseId;
        public string strCourseName;
        public int intType;		//1 cti, 2 IPD, 3 test, 4 canned course, 5 seminar course, 
        //100 jordan test course[new]
        public string strFTPHost;
        public string strDataPath;

        //screen shot related parameter, the COL system doesn't use, I only keep it as original and didn't change it
        public uint intSCWidth;
        public uint intSCHeight;
        public uint intSCInterval;
        public uint intSCHDivide;	// in pixel
        public uint intSCVDivide;   // in pixel
        public uint intSC_hcolorbits; // bit
        public uint intSC_lcolorbits; // bit

        // video capture parameters
        public uint intHVideo_rate;
        public uint intHVideo_width;
        public uint intHVideo_height;
        public uint intLVideo_rate;
        public uint intLVideo_width;
        public uint intLVideo_height;
        public uint intlvideo_img_interval; // in second
        public uint intChop_length;// in second
        public uint intDenoise;// if using denoise

        // wb capture parameters
        public uint intWB_interval; // in second

        // processing parameters
        public int intProcess_delay;
        public CourseInfo(int param)
        {
            intCourseId = 0;
            strCourseName = "";
            intType = 0;
            strFTPHost = "";
            strDataPath = "";

            intSCWidth = 800;
            intSCHeight = 600;
            intSCInterval = 1;
            intSCHDivide = 8;	// in pixel
            intSCVDivide = 8;   // in pixel
            intSC_hcolorbits = 8; // bit
            intSC_lcolorbits = 4; // bit

            // video capture parameters
            intHVideo_rate = 150;
            intHVideo_width = 320;
            intHVideo_height = 240;
            intLVideo_rate = 17;
            intLVideo_width = 200;
            intLVideo_height = 150;
            intlvideo_img_interval = 1; // in second
            intChop_length = 900;// in second
            intDenoise = 0;// if using denoise

            // wb capture parameters
            intWB_interval = 60; // in second

            // processing parameters
            intProcess_delay = 0;
        }
    };

    public struct CourseRecordInfo
    {
        public DateTime datetimeStartTime;
        public int intStartTimer;		//  modify value for course start time
        public int intLength;			// lenth of course in second
        public bool same(CourseRecordInfo info)
        {
            return info.datetimeStartTime == datetimeStartTime && info.intLength == intLength;
        }
    };

    public class CourseRecordInfoCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            CourseRecordInfo cx = (CourseRecordInfo)x;
            CourseRecordInfo cy = (CourseRecordInfo)y;
            return cx.datetimeStartTime.CompareTo(cy.datetimeStartTime);
        }
    }


    public class EngineStatus
    {
        public string strce_version_;				// version of colengine programs

        public COLEngineStatus ce_status_;					// engine status 
        public string strce_status_;				// status of colengine

        public DateTime dtschedule_timestamp_;		// timestamp of scheudle
        public DateTime dtlocaltime_;
        public string str_recordingcourse_name_;		// name of the course being recorded
        public string str_recordingcourse_id_;		// id of the course being recorded

        public AVCaptureStatus av_status_;
        public string strav_status_;			// status of avcaputre
        public int intcaptureframes_;      // capture of video frames

        public CameraStatus camera_status_;
        public string strcamera_status_;		// status of camera

        public WBCaptureStatus wb_status_;
        public string strwb_status_;			// status of wb capture
        public uint intwb_num_;				// number of wb devices
        public int intwb1events_;
        public int intwb2events_;

        public SoundGrabStatus sg_status_;
        public string strsg_status_;			// status of sound grab

        public SoundDetectStatus sd_status_;
        public string strsd_status_; // status of sound detect

        public SoundSourceStatus ss_status_;
        public string strss_status_; // status of sound sources

        public COLAgentStatus ca_status_;
        public string strca_status_; // status of col agent

        public string strca_version_; // version of col agent

        public COLEngineConfigRecord config_;		// config of colengine

        public int intclassroomid;		//class room id
        public int intfree_disk_;		// free space in disk, in MB
        public bool boolce_agent_connected_; // agent connection status
        public ArrayList arrecent_errors;	// recent errors
    }

    public class COLEngineConfigRecord
    {
        public string strportal_page;		// portal page in server
        public string strinstructor_ip;		// ip address of instructor pc
        public string strupload_user;		// user name of ftp for uploading
        public string strupload_passwd;		// password ftp for uploading
        public int intclassroom_id;		//classroom id
    }

    public class AgentStatus
    {
        public COLAgentStatus status_;    // s
        public string strstatus_;			// status of col agent
        public string strversion_;		// version
        public string strengineip_;		// engine ip
        public bool boolengineconnected_;//connection status for connection with engine\
        public int recorddatabyte_;     //recorded data byte
    }

    public class UploadStatus
    {
        public int ClassID;
        public DateTime ClassStartTime;
        public bool Uploaded;
        public DateTime UploadTime;
        public string ClassDataDir;
        public int WBNum;

        public string DataVersion;
    }

    public class EventReport
    {
        public string eventid;
        public string eventLevel;
        public string eventDescription;
    }

    public class ClassRoomNode
    {
        public ClassRoomInfo classroominfo;
    }

    public class ItemQueryStat
    {
        public int inttotalnum = 0;
        public int intsuccnum = 0;
        public bool succ = false;
        public bool refresh = false;
        public string err = "";
        public string errdetail = "";
        static public void SetItemQueryStat(bool succ, string err, string errdetail, ItemQueryStat itemquerystat)
        {
            itemquerystat.succ = succ;
            itemquerystat.refresh = true;
            itemquerystat.inttotalnum++;
            if (succ)
                itemquerystat.intsuccnum++;
            else
            {
                itemquerystat.err = err;
                itemquerystat.errdetail = errdetail;
            }
        }
    }

    public class SyncItemQueryStat
    {
        public ItemQueryStat itemquerystat;
        public Object SyncObj;
        public SyncItemQueryStat(ItemQueryStat stat, Object sobj)
        {
            itemquerystat = stat;
            SyncObj = sobj;
        }

    }
    public class QueryStat
    {
        public ItemQueryStat enginstatus = new ItemQueryStat();
        public ItemQueryStat agentstatus = new ItemQueryStat();
        public ItemQueryStat schedule = new ItemQueryStat();
        public ItemQueryStat localdata = new ItemQueryStat();
        public ItemQueryStat image = new ItemQueryStat();
        public ItemQueryStat sound = new ItemQueryStat();
    }
    public class ClassRoomInfo
    {

        public Object syncobject;
        public QueryStat querystat;
        public string strName;
        public string strPPCIP;
        public int intPPCPort;
        public string strIPCIP;
        public int intIPCPort;

        public ClassRoomStatus status = ClassRoomStatus.NOTGETYET;
        public EngineStatus enginestatus;
        public AgentStatus agentstatus;

        //  key CourseInfo,  value array of  CourseRecordInfo
        public System.Collections.Hashtable CourseSchedule;

        public ArrayList localcourselist;
        public string strError = "";
        public ClassRoomInfo()
        {
            syncobject = new Object();
            querystat = new QueryStat();
        }
        public void Set_ClassRoomStatus(COLEngineStatus estatus)
        {
            switch (estatus)
            {
                case COLEngineStatus.COLENGINE_IDLE:
                    status = ClassRoomStatus.IDLE;
                    break;
                case COLEngineStatus.COLENGINE_RECORDING:
                    status = ClassRoomStatus.RECORDING;
                    break;
                case COLEngineStatus.COLENGINE_ONESTEPPROCESSING:
                case COLEngineStatus.COLENGINE_PROCESSING:
                    status = ClassRoomStatus.PROCESSING;
                    break;
                case COLEngineStatus.COLENGINE_UPLOADING:
                    status = ClassRoomStatus.UPLOADING;
                    break;
                case COLEngineStatus.COLENGINE_WAITINGPENDING:
                case COLEngineStatus.COLENGINE_WAITINGUPLOAD:
                    status = ClassRoomStatus.WAITING;
                    break;
                case COLEngineStatus.COLENGINE_DELETINGDATA:
                    status = ClassRoomStatus.DELETTING;
                    break;
                default:
                    status = ClassRoomStatus.UNKNOWN;
                    break;
            }
        }
    }

    public class ClassRoomInfoCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            ClassRoomInfo cx = (ClassRoomInfo)x;
            ClassRoomInfo cy = (ClassRoomInfo)y;
            return cx.strName.CompareTo(cy.strName);
        }
    }

    public class StatusString
    {
        static public string CourseType(int type)
        {
            return (type == 100 ? "RA Test Class" : "Depaul Class");
        }
        static public string Status(ClassRoomStatus status)
        {
            switch (status)
            {
                case ClassRoomStatus.NOTGETYET:
                    return "unknown";
                case ClassRoomStatus.GETTING:
                    return "Communitcattting ";
                case ClassRoomStatus.IDLE:
                    return "idle";
                case ClassRoomStatus.RECORDING:
                    return "recording";
                case ClassRoomStatus.WAITING:
                    return "waiting";
                case ClassRoomStatus.PROCESSING:
                    return "processing";
                case ClassRoomStatus.DELETTING:
                    return "deletting";
                case ClassRoomStatus.UPLOADING:
                    return "uploading";
                case ClassRoomStatus.ERROR:
                    return "error";
                case ClassRoomStatus.UNKNOWN:
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(ClassRoomStatus status)
        {
            switch (status)
            {
                case ClassRoomStatus.NOTGETYET:
                case ClassRoomStatus.GETTING:
                case ClassRoomStatus.IDLE:
                case ClassRoomStatus.RECORDING:
                case ClassRoomStatus.WAITING:
                case ClassRoomStatus.PROCESSING:
                case ClassRoomStatus.DELETTING:
                case ClassRoomStatus.UPLOADING:
                    return true;
                case ClassRoomStatus.ERROR:
                case ClassRoomStatus.UNKNOWN:
                default:
                    return false;
            }
        }
        static public string Status(COLEngineStatus status)
        {
            switch (status)
            {
                case COLEngineStatus.COLENGINE_IDLE:
                    return "Idle";
                case COLEngineStatus.COLENGINE_RECORDING:
                    return "Recording";
                case COLEngineStatus.COLENGINE_PROCESSING:
                case COLEngineStatus.COLENGINE_ONESTEPPROCESSING:
                    return "Processing";
                case COLEngineStatus.COLENGINE_UPLOADING:
                    return "Uploading";
                case COLEngineStatus.COLENGINE_WAITINGPENDING:
                    return "Waiting job";
                case COLEngineStatus.COLENGINE_WAITINGUPLOAD:
                    return "waiting upload";
                case COLEngineStatus.COLENGINE_DELETINGDATA:
                    return "deleting";
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(COLEngineStatus status)
        {
            switch (status)
            {
                case COLEngineStatus.COLENGINE_IDLE:
                case COLEngineStatus.COLENGINE_RECORDING:
                case COLEngineStatus.COLENGINE_PROCESSING:
                case COLEngineStatus.COLENGINE_ONESTEPPROCESSING:
                case COLEngineStatus.COLENGINE_UPLOADING:
                case COLEngineStatus.COLENGINE_WAITINGPENDING:
                case COLEngineStatus.COLENGINE_WAITINGUPLOAD:
                case COLEngineStatus.COLENGINE_DELETINGDATA:
                    return true;
                default:
                    return false;
            }
        }
        static public string Status(COLAgentStatus status)
        {
            switch (status)
            {
                case COLAgentStatus.COLAGENT_IDLE:
                    return "Idle";
                case COLAgentStatus.COLAGENT_RECORDING:
                    return "Recording";
                case COLAgentStatus.COLAGENT_ERROR:
                    return "Error";
                case COLAgentStatus.COLAGENT_DISABLED:
                    return "Disabled";
                case COLAgentStatus.COLAGENT_NORESPONSE:
                    return "No Response";
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(COLAgentStatus status)
        {
            switch (status)
            {
                case COLAgentStatus.COLAGENT_IDLE:
                case COLAgentStatus.COLAGENT_RECORDING:
                case COLAgentStatus.COLAGENT_DISABLED:
                    return true;
                case COLAgentStatus.COLAGENT_ERROR:
                case COLAgentStatus.COLAGENT_NORESPONSE:
                default:
                    return false;
            }
        }
        static public string Status(AVCaptureStatus status)
        {
            switch (status)
            {
                case AVCaptureStatus.AVCapture_NoResponse:
                    return "No Response";				// for AVCapture_NoResponse
                case AVCaptureStatus.AVCapture_Idle:
                    return "idle";						// for AVCapture_Idle
                case AVCaptureStatus.AVCapture_Initialized:
                case AVCaptureStatus.AVCapture_Running:
                    return "Capturing";
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(AVCaptureStatus status)
        {
            switch (status)
            {
                case AVCaptureStatus.AVCapture_Idle:
                case AVCaptureStatus.AVCapture_Initialized:
                case AVCaptureStatus.AVCapture_Running:
                    return true;
                case AVCaptureStatus.AVCapture_NoResponse:
                default:
                    return false;
            }
        }
        static public string Status(CameraStatus status)
        {
            switch (status)
            {
                case CameraStatus.Camera_Off:
                    return "Off";				// for Camera_Off
                case CameraStatus.Camera_On:
                    return "On";				// for Camera_On
                default:
                    return "unkonwn";
            }
        }
        static public bool BeOK(CameraStatus status)
        {
            switch (status)
            {
                case CameraStatus.Camera_On:
                    return true;
                case CameraStatus.Camera_Off:
                default:
                    return false;
            }
        }
        static public string Status(WBCaptureStatus status)
        {
            switch (status)
            {
                case WBCaptureStatus.WBCapture_NoResponse:
                    return "No Response";					// for WBCapture_NoResponse
                case WBCaptureStatus.WBCapture_Initialized:
                    return "Initialized";					// for WBCapture_Initialized
                case WBCaptureStatus.WBCapture_Ready:
                    return "Ready";							// for WBCapture_Ready
                case WBCaptureStatus.WBCapture_Recording:
                    return "Capturing";						// for WBCapture_Running
                case WBCaptureStatus.WBCapture_FailInit:
                    return "Fail init";						// for WBCapture_FailInit
                case WBCaptureStatus.WBCapture_FailStart:
                    return "Fail start";					// for WBCapture_FailStart
                case WBCaptureStatus.WBCapture_Created:
                    return "Created";						// for WBCapture_Created
                case WBCaptureStatus.WBCapture_Paused:
                    return "Paused";						// for WBCapture_Paused
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(WBCaptureStatus status)
        {
            switch (status)
            {
                case WBCaptureStatus.WBCapture_Initialized:
                case WBCaptureStatus.WBCapture_Ready:
                case WBCaptureStatus.WBCapture_Recording:
                case WBCaptureStatus.WBCapture_Created:
                case WBCaptureStatus.WBCapture_Paused:
                    return true;
                case WBCaptureStatus.WBCapture_NoResponse:
                case WBCaptureStatus.WBCapture_FailInit:
                case WBCaptureStatus.WBCapture_FailStart:
                default:
                    return false;
            }
        }
        static public string Status(SoundGrabStatus status)
        {
            switch (status)
            {
                case SoundGrabStatus.SoundGrab_NoResponse:
                    return "No Response";				// for SoundGrab_NoResponse
                case SoundGrabStatus.SoundGrab_Idle:
                    return "idle";						// for SoundGrab_Idle
                case SoundGrabStatus.SoundGrab_Running:
                    return "Grabbing";					// for SoundGrab_Running
                case SoundGrabStatus.SoundGrab_Error:
                    return "Error";						// for SoundGrab_Error
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(SoundGrabStatus status)
        {
            switch (status)
            {
                case SoundGrabStatus.SoundGrab_Idle:
                case SoundGrabStatus.SoundGrab_Running:
                    return true;
                case SoundGrabStatus.SoundGrab_NoResponse:
                case SoundGrabStatus.SoundGrab_Error:
                default:
                    return false;
            }
        }
        static public string Status(SoundDetectStatus status)
        {
            switch (status)
            {
                case SoundDetectStatus.SoundDetect_NoResponse:
                    return "No Response";			// for SoundDetect_NoResponse
                case SoundDetectStatus.SoundDetect_Idle:
                    return "idle";					// for SoundDetect_Idle
                case SoundDetectStatus.SoundDetect_Running:
                    return "detecting";				// for SoundDetect_Running
                case SoundDetectStatus.SoundDetect_Error:
                    return "Error";					// for SoundDetect_Error
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(SoundDetectStatus status)
        {
            switch (status)
            {
                case SoundDetectStatus.SoundDetect_Idle:
                case SoundDetectStatus.SoundDetect_Running:
                case SoundDetectStatus.SoundDetect_NoResponse:
                    return true;			// for SoundDetect_NoResponse
                case SoundDetectStatus.SoundDetect_Error:
                default:
                    return false;
            }
        }
        static public string Status(SoundSourceStatus status)
        {
            switch (status)
            {
                case SoundSourceStatus.Sound_Connected:
                    return "Connected";							// for Sound_Disconnected
                case SoundSourceStatus.Must_Be_Connection_Error:
                    return "Disconnected";						// for Sound_Connected
                case SoundSourceStatus.Could_Be_Mixer_Problem:
                    return "Mixer problem";						// for Could_Be_Mixer_Problem
                case SoundSourceStatus.Could_Be_Mixer_Volume_Too_Low:
                    return "Mixer volume too low";				// for Could_Be_Mixer_Volume_Too_Low
                case SoundSourceStatus.Could_Be_Connection_Problem:
                    return "Connection problem";				// for Could_Be_Connection_Problem
                case SoundSourceStatus.Could_Be_Mixer_Problem_Or_Connection_Problem:
                    return "Mixer/connection problem";			// for Could_Be_Mixer_Problem_Or_Connection_Problem
                case SoundSourceStatus.Grab_Error:
                    return "Sound Grab error";					// for Grab_Error
                case SoundSourceStatus.Error_Low_Volume:
                    return "low volume,Check Connections / PPC Audio Settings";
                case SoundSourceStatus.Warning_Low_Volume:
                    return "low volume,Check Audio Mixer / PPC Volume Settings";
                case SoundSourceStatus.Unknown_Problem:
                    return "Unknown problem";					// Unknown_Problem
                default:
                    return "unknown";
            }
        }
        static public bool BeOK(SoundSourceStatus status)
        {
            switch (status)
            {
                case SoundSourceStatus.Sound_Connected:
                    return true;							// for Sound_Disconnected
                case SoundSourceStatus.Must_Be_Connection_Error:
                case SoundSourceStatus.Could_Be_Mixer_Problem:
                case SoundSourceStatus.Could_Be_Mixer_Volume_Too_Low:
                case SoundSourceStatus.Could_Be_Connection_Problem:
                case SoundSourceStatus.Could_Be_Mixer_Problem_Or_Connection_Problem:
                case SoundSourceStatus.Grab_Error:
                case SoundSourceStatus.Error_Low_Volume:
                case SoundSourceStatus.Warning_Low_Volume:
                case SoundSourceStatus.Unknown_Problem:
                default:
                    return false;
            }
        }
    }
    public class ErrorCharInNode
    {
        static public string Status(COLEngineStatus status)
        {
            switch (status)
            {
                case COLEngineStatus.COLENGINE_IDLE:
                case COLEngineStatus.COLENGINE_RECORDING:
                case COLEngineStatus.COLENGINE_PROCESSING:
                case COLEngineStatus.COLENGINE_ONESTEPPROCESSING:
                case COLEngineStatus.COLENGINE_UPLOADING:
                case COLEngineStatus.COLENGINE_WAITINGPENDING:
                case COLEngineStatus.COLENGINE_WAITINGUPLOAD:
                case COLEngineStatus.COLENGINE_DELETINGDATA:
                    return "";
                default:
                    return "E";
            }
        }
        static public string Status(COLAgentStatus status)
        {
            switch (status)
            {
                case COLAgentStatus.COLAGENT_IDLE:
                case COLAgentStatus.COLAGENT_RECORDING:
                case COLAgentStatus.COLAGENT_DISABLED:
                    return "";
                case COLAgentStatus.COLAGENT_ERROR:
                case COLAgentStatus.COLAGENT_NORESPONSE:
                default:
                    return "A";
            }
        }
        static public string Status(AVCaptureStatus status)
        {
            switch (status)
            {
                case AVCaptureStatus.AVCapture_Idle:
                case AVCaptureStatus.AVCapture_Initialized:
                case AVCaptureStatus.AVCapture_Running:
                    return "";
                case AVCaptureStatus.AVCapture_NoResponse:
                default:
                    return "V";
            }
        }
        static public string Status(CameraStatus status)
        {
            switch (status)
            {
                case CameraStatus.Camera_On:
                    return "";				// for Camera_On
                case CameraStatus.Camera_Off:
                default:
                    return "C";
            }
        }
        static public string Status(WBCaptureStatus status)
        {
            switch (status)
            {
                case WBCaptureStatus.WBCapture_Initialized:
                case WBCaptureStatus.WBCapture_Ready:
                case WBCaptureStatus.WBCapture_Recording:
                case WBCaptureStatus.WBCapture_Created:
                case WBCaptureStatus.WBCapture_Paused:
                    return "";						// for WBCapture_Paused
                case WBCaptureStatus.WBCapture_FailInit:
                case WBCaptureStatus.WBCapture_FailStart:
                case WBCaptureStatus.WBCapture_NoResponse:
                default:
                    return "W";
            }
        }
        static public string Status(SoundGrabStatus status)
        {
            switch (status)
            {
                case SoundGrabStatus.SoundGrab_Idle:
                case SoundGrabStatus.SoundGrab_Running:
                    return "";					// for SoundGrab_Running
                case SoundGrabStatus.SoundGrab_NoResponse:
                case SoundGrabStatus.SoundGrab_Error:
                default:
                    return "G";
            }
        }
        static public string Status(SoundDetectStatus status)
        {
            switch (status)
            {
                case SoundDetectStatus.SoundDetect_Idle:
                case SoundDetectStatus.SoundDetect_Running:
                    return "";				// for SoundDetect_Running
                case SoundDetectStatus.SoundDetect_NoResponse:
                case SoundDetectStatus.SoundDetect_Error:
                default:
                    return "D";
            }
        }
        static public string Status(SoundSourceStatus status)
        {
            switch (status)
            {
                case SoundSourceStatus.Sound_Connected:
                    return "";							// for Sound_Disconnected
                case SoundSourceStatus.Must_Be_Connection_Error:
                case SoundSourceStatus.Could_Be_Mixer_Problem:
                case SoundSourceStatus.Could_Be_Mixer_Volume_Too_Low:
                case SoundSourceStatus.Could_Be_Connection_Problem:
                case SoundSourceStatus.Could_Be_Mixer_Problem_Or_Connection_Problem:
                case SoundSourceStatus.Grab_Error:
                case SoundSourceStatus.Error_Low_Volume:
                case SoundSourceStatus.Warning_Low_Volume:
                case SoundSourceStatus.Unknown_Problem:
                default:
                    return "S";
            }
        }
    }
}