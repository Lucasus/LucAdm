namespace LucAdm
{
    public class OperationResponse<TResult> : OperationResponse
    {
        public TResult Result { get; private set; }

        public OperationResponse(TResult result, ValidationResult validationResult = null)
        {
            this.Result = result;
            this.ValidationResult = validationResult ?? new ValidationResult();
        }
    }
}