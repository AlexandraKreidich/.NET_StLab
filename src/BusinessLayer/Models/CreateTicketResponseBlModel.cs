namespace BusinessLayer.Models
{
    public class CreateTicketResponseBlModel
    {
        public StoredProcedureExecutionResult Result { get; }

        public int TicketId { get; }

        public CreateTicketResponseBlModel(
            StoredProcedureExecutionResult result,
            int ticketId
        )
        {
            Result = result;
            TicketId = ticketId;
        }
    }
}
