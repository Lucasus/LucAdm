namespace LucAdm
{
    public class OperationResponse
    {
        public ValidationResult ValidationResult { get; set; }

        public OperationResponse(ValidationResult validationResult = null)
        {
            this.ValidationResult = validationResult ?? new ValidationResult();            
        }
    }

}
