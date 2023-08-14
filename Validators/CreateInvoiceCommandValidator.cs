using CQRS_PipelineBehaviour.Features.InvoiceFeature.Commands;
using FluentValidation;

namespace CQRS_PipelineBehaviour.Validators
{
    public class CreateInvoiceCommandValidator  : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(c => c.InvoiceDate).NotEmpty();
            RuleFor(c => c.Total).NotEmpty();
        }
    }
}
