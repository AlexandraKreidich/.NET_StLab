namespace DataAccessLayer.Models.DataTransferObjects
{
    public class SessionServiceModel
    {
        public int SessionId { get; set; }

        public int ServiceId { get; set; }

        public SessionServiceModel(
            int sessionId,
            int serviceId
        )
        {
            ServiceId = serviceId;
            SessionId = sessionId;
        }
    }
}
