using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
