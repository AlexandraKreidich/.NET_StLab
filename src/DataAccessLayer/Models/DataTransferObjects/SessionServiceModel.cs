namespace DataAccessLayer.Models.DataTransferObjects
{
    public class SessionServiceModel
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int ServiceId { get; set; }

        public SessionServiceModel(
            int sessionId,
            int serviceId,
            int id = 0
        )
        {
            ServiceId = serviceId;
            SessionId = sessionId;
            Id = id;
        }
    }
}
