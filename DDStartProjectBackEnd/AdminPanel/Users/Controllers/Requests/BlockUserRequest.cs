namespace DDStartProjectBackEnd.AdminPanel.Users.Controllers.Requests
{
    public class BlockUserRequest
    {
        public string Id { get; set; }
        public string Reason { get; set; }
        public bool SaveAsTemplate { get; set; }
    }
}
