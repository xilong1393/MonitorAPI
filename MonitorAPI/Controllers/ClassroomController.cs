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
        public List<ClassroomGroup> GetClassroomGroupList()
        {
            try
            {
                ClassroomGroupService service = ServiceFactory.ClassroomGroupService;
                List<ClassroomGroup> list = service.GetClassroomGroups(" ");
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                throw;
            }
            
        }
        [HttpPost]
        public List<ClassroomView> GetClassroomListByGroupID(GetClassroomListForm getClassroomListForm) {
            try
            {
                ClassroomService service = ServiceFactory.ClassroomService;
                List<ClassroomView> list = service.GetClassroomListByGroupID(getClassroomListForm.SessionID, getClassroomListForm.GroupID);
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().Error(ex.ToString());
                throw;
            }
            
        }
    }
}