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
            ClassroomGroupService service = ClassroomGroupService.Instance;
            List<ClassroomGroup> list = service.GetClassroomGroups(" ");
            return list;
        }
        [HttpPost]
        public List<ClassroomView> GetClassroomListByGroupID(GetClassroomListForm getClassroomListForm) {
            ClassroomService service = ClassroomService.Instance;
            List<ClassroomView> list = service.GetClassroomListByGroupID(getClassroomListForm.SessionID, getClassroomListForm.GroupID);
            return list;
        }
    }
}