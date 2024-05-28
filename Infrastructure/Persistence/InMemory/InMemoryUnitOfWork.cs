using Domain.Abstractions;

namespace Infrastructure.Persistence.InMemory
{
    public sealed class InMemoryUnitOfWork : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
