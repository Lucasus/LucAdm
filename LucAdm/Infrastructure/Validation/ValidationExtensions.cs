using System;
using FluentValidation;

namespace LucAdm
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates command with validator and creates validation result with validation errors
        /// </summary>
        public static ValidationResult Validate<TCommand>(this TCommand command, AbstractValidator<TCommand> validator)
        {
            var validationResult = new ValidationResult();
            foreach (var error in validator.Validate(command).Errors)
            {
                validationResult.AddError(error.PropertyName, error.ErrorMessage);
            }
            return validationResult;
        }
       
        /// <summary>
        /// Checks rule but only if validation result is still valid, and adds rule validation errors to it
        /// </summary>
        public static ValidationResult Check(this ValidationResult validationResult, params IRule[] rules)
        {
            if (validationResult.IsValid)
            {
                foreach (var rule in rules)
                {
                    if (!rule.Check())
                    {
                        validationResult.AddError(rule.Name, rule.ErrorMessage);
                    }
                }
            }
            return validationResult;
        }

        /// <summary>
        /// Executes operation if a validation result contains no errors and returns response with this validation result
        /// </summary>
        public static OperationResponse IfValid(this ValidationResult validationResult, Action operation)
        {
            return IfValid(validationResult, result => operation());
        }

        /// <summary>
        /// Executes operation if a validation result contains no errors and returns response with this validation result
        /// </summary>
        public static OperationResponse IfValid(this ValidationResult validationResult, Action<ValidationResult> operation)
        {
            if (validationResult.IsValid)
            {
                operation(validationResult);
            }
            return new OperationResponse(validationResult);
        }

        /// <summary>
        /// Executes operation if a validation result contains no errors and returns response with this validation result
        /// </summary>
        public static OperationResponse IfValid(this ValidationResult validationResult, Func<OperationResponse> operation)
        {
            return IfValid(validationResult, result => operation());
        }

        /// <summary>
        /// Executes operation if a validation result contains no errors and returns response with this validation result
        /// </summary>
        public static OperationResponse IfValid(this ValidationResult validationResult, Func<ValidationResult, OperationResponse> operation)
        {
            if (validationResult.IsValid)
            {
                return operation(validationResult);
            }
            return new OperationResponse(validationResult);
        }

        /// <summary>
        /// Executes operation if a validation result contains no errors and returns response with this validation result
        /// </summary>
        public static OperationResponse<TResult> IfValid<TResult>(this ValidationResult validationResult, Func<OperationResponse<TResult>> operation)
        {
            return IfValid(validationResult, result => operation());
        }

        /// <summary>
        /// Executes operation if a validation result contains no errors and returns response with this validation result
        /// </summary>
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