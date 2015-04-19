using FluentValidation;

namespace LucAdm
{
    public class IdValidator : AbstractValidator<Validated<int>>
    {
        public IdValidator()
        {
            RuleFor(x => x.IsValid).Equal(true);
            RuleFor(x => x.Value).GreaterThan(0);
        }
    }
}