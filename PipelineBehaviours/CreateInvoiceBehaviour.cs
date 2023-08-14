using CQRS_PipelineBehaviour.Features.InvoiceFeature.Commands;
using FluentValidation;
using MediatR;

namespace CQRS_PipelineBehaviour.PipelineBehaviours;

public class CreateInvoiceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CreateInvoiceBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var invoiceData = request as CreateInvoiceCommand;
        if (invoiceData is not null)
        {
            if(invoiceData.Total<1000 && invoiceData.Discount > 15)
            {
                throw new ArgumentException("Discount for a total less than 1000 can not be more than 15");
            }
        }
        return await next();
    }
}
