using System;
using FluentValidation;

namespace LucAdm
{
    public static class ValidationExtensions
    {
        public static ValidationResult Validate<TCommand>(this TCommand command, AbstractValidator<TCommand> validator)
        {
            var validationResult = new ValidationResult();
            foreach (var error in validator.Validate(command).Errors)
            {
                validationResult.AddError(error.PropertyName, error.ErrorMessage);
            }
            return validationResult;
        }
       
        public static ValidationResult Check(this ValidationResult validationResult, params Rule[] rules)
        {
            if (validationResult.IsValid)
            {
                foreach (var rule in rules)
                {
                    if (!rule.Check())
                    {
                        validationResult.AddError(rule.Name, rule.Message);
                    }
                }
            }
            return validationResult;
        }

        public static OperationResponse IfValid(this ValidationResult validationResult, Action operation)
        {
            return IfValid(validationResult, result => operation());
        }

        public static OperationResponse IfValid(this ValidationResult validationResult, Action<ValidationResult> operation)
        {
            if (validationResult.IsValid)
            {
                operation(validationResult);
            }
            return new OperationResponse(validationResult);
        }

        public static OperationResponse IfValid(this ValidationResult validationResult, Func<OperationResponse> operation)
        {
            return IfValid(validationResult, result => operation());
        }

        public static OperationResponse IfValid(this ValidationResult validationResult, Func<ValidationResult, OperationResponse> operation)
        {
            if (validationResult.IsValid)
            {
                return operation(validationResult);
            }
            return new OperationResponse(validationResult);
        }

        public static OperationResponse<TResult> IfValid<TResult>(this ValidationResult validationResult, Func<OperationResponse<TResult>> operation)
        {
            return IfValid(validationResult, result => operation());
        }

        public static OperationResponse<TResult> IfValid<TResult>(this ValidationResult validationResult, Func<ValidationResult, OperationResponse<TResult>> operation)
        {
            if (validationResult.IsValid)
            {
                return operation(validationResult);
            }
            return new OperationResponse<TResult>(default(TResult), validationResult);
        }

    }
}