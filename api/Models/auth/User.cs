using hrm_api.Models.hr;
namespace hrm_api.Models.auth
{
    public class User
    {
        public string ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string employee { get; set; }
        public string status { get; set; }
        public string role { get; set; }
        public string rule { get; set; }
    }
}