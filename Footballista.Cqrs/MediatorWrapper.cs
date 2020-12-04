using Footballista.Cqrs.Base.Commands;
using Footballista.Cqrs.Base.Queries;
using MediatR;
using System.Threading.Tasks;

namespace Footballista.Cqrs
{
    /// <inheritdoc/>
    public class MediatorWrapper : IMediatorWrapper
    {
        private readonly IMediator _mediator;

        public MediatorWrapper(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <inheritdoc/>
        public async Task DispatchAsync(ICommand command)
        {
            await _mediator.Send(command);
        }

        /// <inheritdoc/>
        public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command)
        {
            return await _mediator.Send(command);
        }

        /// <inheritdoc/>
        public async Task<TResponse> GetResultAsync<TResponse>(IQuery<TResponse> query)
        {
            return await _mediator.Send(query);
        }
    }
}
