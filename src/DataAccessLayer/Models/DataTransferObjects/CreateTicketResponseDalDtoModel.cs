namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CreateTicketResponseDalDtoModel
    {
        public StoredProcedureExecutionResult Result { get; }

        public int TicketId { get; }

        public CreateTicketResponseDalDtoModel(
            StoredProcedureExecutionResult result,
            int ticketId
        )
        {
            Result = result;
            TicketId = ticketId;
        }
    }
}
