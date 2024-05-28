using Application.Products.Queries;
using FastEndpoints;
using MediatR;

namespace Ui.Api.Products.Endpoints.GetProductStock
{
    public class GetProductStockEndpoint(ISender sender)
        : Endpoint<GetProductStockRequest, GetProductStockResponse>
    {
        public override void Configure()
        {
            Get("products/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            GetProductStockRequest request,
            CancellationToken cancellationToken)
        {
            int result = await sender.Send(new GetProductStockQuery(request.Id), cancellationToken);

            await SendAsync(
                new GetProductStockResponse(result),
                cancellation: cancellationToken);
        }
    }
}
