using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using MonitorAPI.Models.ParameterForm;
using MonitorAPI.Service;
using MonitorAPI.Service.Operations;
using MonitorAPI.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace MonitorAPI.Controllers
{
    public class OperationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult PushSchedule(int classroomID, string sessionID) {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.PushSchedule(classroomID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        [HttpGet]
        public IHttpActionResult StopRecord(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.StopRecord(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        [HttpGet]
        public IHttpActionResult AbortRecord(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.AbortRecord(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //puch config
        [HttpGet]
        public IHttpActionResult PushPPCConfig(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.UpdatePPCConfig(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //puch config
        [HttpGet]
        public IHttpActionResult GetImageString(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.GetImageString(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        [HttpGet]
        public IHttpActionResult GetAudioData(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.GetAudioData(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //check schedule
        [HttpGet]
        public IHttpActionResult CheckSchedule(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.CheckSchedule(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //classroom Info
        [HttpGet]
        public IHttpActionResult ClassroomInfo(int classroomID, string sessionID)
        {
            try
            {
                ClassroomService service = ServiceFactory.ClassroomService;
                ClassroomInfoView classroom = service.GetClassroomDetailByGroupID(sessionID, classroomID);
                if (classroom != null)
                    return Ok(classroom);
                else
                {
                    return BadRequest("classroom doesn't exist");
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //Group schedule
        [HttpGet]
        public IHttpActionResult GroupSchedule(int groupID, string sessionID)
        {
            try
            {
                ClassroomService service = ServiceFactory.ClassroomService;
                List<ClassroomScheduleView> list = service.GetClassroomScheduleByGroupID(sessionID,groupID);
                return Ok(list);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }
        [HttpGet]
        public IHttpActionResult RebootPPC(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.RebootPPC(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        [HttpGet]
        public IHttpActionResult RebootIPC(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.RebootIPC(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }
        //list local record
        [HttpGet]
        public IHttpActionResult ListLocalData(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.ListLocalData(classroomID, sessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //upload local record
        [HttpPost]
        public IHttpActionResult UploadLocalData(UploadLocalDataForm form)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.UploadLocalCourse(form.ClassroomID, form.Dirnames, form.SessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //delete local record
        [HttpPost]
        public IHttpActionResult DeleteLocalData(UploadLocalDataForm form)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                CommandParameter parameter = service.DeleteLocalCourse(form.ClassroomID, form.Dirnames, form.SessionID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                {
                    LogHelper.GetLogger().Error(parameter.error);
                    return BadRequest(parameter.error);
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //start test course
        [HttpPost]
        public IHttpActionResult StartTestCourse(UploadLocalDataForm form)
        {
            try
            {
                TestCourseService service = ServiceFactory.TestCourseService;
                ClassroomService classroomService = ServiceFactory.ClassroomService;
                Classroom classroom = classroomService.GetClassroomByID(form.ClassroomID);

                List<Quater> qlist = service.GetAllQuarter();
                List<FileServer> flist = service.GetAllFileServer();
                List<ClassType> clist = service.GetAllClassType();
                return Ok(new TestCourseReturnModel(qlist, flist, clist, classroom));
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        //submit start test course
        [HttpPost]
        public IHttpActionResult SubmitStartTestCourse(ClassSchedule classSchedule)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                bool res = service.InsertClassSchedule(classSchedule);
                //if (!res)
                //    return BadRequest("Insert class schedule failed");
                CommandParameter parameter = service.PushSchedule(classSchedule.ClassroomID);
                if (parameter.succ)
                    return Ok(parameter);
                else
                    return BadRequest(parameter.error);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

        [HttpGet]
        public IHttpActionResult GetClassroomStatusbyClassroomID(int classroomID, string sessionID)
        {
            try
            {
                OperationService service = ServiceFactory.OperationService;
                ClassroomEngineAgentStatus res = service.GetClassroomStatusbyClassroomID(classroomID);
                return Ok(res);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest("something is wrong");
            }
        }

    }
}