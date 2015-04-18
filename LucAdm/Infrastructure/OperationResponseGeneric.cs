namespace LucAdm
{
    public class OperationResponse<TResult> : OperationResponse
    {
        public OperationResponse(TResult result, ValidationResult validationResult = null)
        {
            Result = result;
            ValidationResult = validationResult ?? new ValidationResult();
        }

        public TResult Result { get; private set; }
    }
}