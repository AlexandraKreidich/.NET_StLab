namespace DataAccessLayer
{
    public enum StoredProcedureExecutionResult
    {
        Ok,
        ForeignKeyViolation,
        UniqueKeyViolation // 2627
    }
}
