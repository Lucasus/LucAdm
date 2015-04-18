namespace LucAdm
{
    public class OperationResponse
    {
        public OperationResponse(ValidationResult validationResult = null)
        {
            ValidationResult = validationResult ?? new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }
    }
}