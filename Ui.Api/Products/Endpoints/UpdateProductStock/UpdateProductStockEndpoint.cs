using Application.Products.Commands;
using FastEndpoints;
using MediatR;

namespace Ui.Api.Products.Endpoints.UpdateProductStock
{
    public class UpdateProductStockEndpoint(ISender sender)
        : Endpoint<UpdateProductStockRequest>
    {
        public override void Configure()
        {
            Post("products/{Id}/stock");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            UpdateProductStockRequest request,
            CancellationToken cancellationToken)
        {
            await sender.Send(
                new UpdateProductStockCommand(request.Id, request.Stock),
                cancellationToken);

            await SendAsync(null, cancellation: cancellationToken);
        }
    }
}
