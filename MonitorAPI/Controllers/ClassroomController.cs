using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Service;
using MonitorAPI.Util;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MonitorAPI.Controllers
{
    public class ClassroomController : ApiController
    {
        public IHttpActionResult GetClassroomGroupList()
        {
            try
            {
                ClassroomGroupService service = ServiceFactory.ClassroomGroupService;
                List<ClassroomGroup> list = service.GetClassroomGroups(" ");
                return Ok(list);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
            
        }
        [HttpPost]
        public IHttpActionResult GetClassroomListByGroupID(GetClassroomListForm getClassroomListForm) {
            try
            {
                ClassroomService service = ServiceFactory.ClassroomService;
                List<ClassroomView> list = service.GetClassroomListByGroupID(getClassroomListForm.SessionID, getClassroomListForm.GroupID);
                return Ok(list);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
            
        }
    }
}