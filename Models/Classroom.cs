namespace MonitorAPI.Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public string ClassroomName { get; set; }
        public string PSClassroomName { get; set; }
        public int ClassroomGroupID { get; set; }
        public string PPCPublicIP { get; set; }
        public string IPCPublicIP { get; set; }
        public int SvrPortalPageID { get; set; }
        public string PPCPrivateIP { get; set; }
        public string IPCPrivateIP { get; set; }
        public int PPCPort { get; set; }
        public int IPCPort { get; set; }
        public int WBNumber { get; set; }
        public int Status { get; set; }
    }
}