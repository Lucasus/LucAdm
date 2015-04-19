namespace LucAdm
{
    public class OperationResponse<TResult> : OperationResponse
    {
        public OperationResponse(TResult result, ValidationResult validationResult = null)
            : base(validationResult)
        {
            Result = result;
        }

        public TResult Result { get; private set; }
    }
}