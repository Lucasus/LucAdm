using FluentValidation;
using System;

namespace LucAdm
{
    public static class ValidationExtensions
    {
        public static ValidationResult IsValid<TCommand>(this TCommand command, AbstractValidator<TCommand> validator)
        where TCommand : IValidatable
        {
            var validationResult = new ValidationResult();
            foreach (var error in validator.Validate(command).Errors)
            {
                validationResult.AddError(error.PropertyName, error.ErrorMessage);
            }
            return validationResult;
        }

        public static ValidationResult And(this ValidationResult validationResult, params Rule[] rules)
        {
            if(validationResult.IsValid)
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

        public static OperationResponse<TResult> Then<TResult>(this ValidationResult validationResult, Func<ValidationResult, OperationResponse<TResult>> operation)
        {
            if (validationResult.IsValid)
            {
                return operation(validationResult);
            }
            return new OperationResponse<TResult>(default(TResult), validationResult);
        }

        public static OperationResponse<TResult> Then<TResult>(this ValidationResult validationResult, Func<OperationResponse<TResult>> operation)
        {
            if (validationResult.IsValid)
            {
                return operation();
            }
            return new OperationResponse<TResult>(default(TResult), validationResult);
        }
    }
}