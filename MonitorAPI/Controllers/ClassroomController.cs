using MonitorAPI.Model;
using MonitorAPI.Models;
using MonitorAPI.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace MonitorAPI.Controllers
{
    public class ClassroomController : ApiController
    {
        public List<ClassroomGroup> GetClassroomGroupList()
        {
            ClassroomGroupService service = ServiceFactory.ClassroomGroupService;
            List<ClassroomGroup> list = service.GetClassroomGroups(" ");
            return list;
        }
        [HttpPost]
        public List<ClassroomView> GetClassroomListByGroupID(GetClassroomListForm getClassroomListForm) {
            ClassroomService service = ServiceFactory.ClassroomService;
            List<ClassroomView> list = service.GetClassroomListByGroupID(getClassroomListForm.SessionID, getClassroomListForm.GroupID);
            return list;
        }
    }
}