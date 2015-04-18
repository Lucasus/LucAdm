namespace LucAdm
{
    public class OperationResponse
    {
        protected OperationResponse(ValidationResult validationResult = null)
        {
            ValidationResult = validationResult ?? new ValidationResult();
        }

        public ValidationResult ValidationResult { get; protected set; }
    }
}