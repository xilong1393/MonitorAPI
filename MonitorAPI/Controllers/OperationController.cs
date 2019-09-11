using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Models.OperationModel;
using MonitorAPI.Service;
using MonitorAPI.Service.Operations;
using MonitorAPI.Util;
using System;
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

        //list local record
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
                ClassroomView classroom = service.GetClassroomDetailByGroupID(sessionID, classroomID);
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
    }
}