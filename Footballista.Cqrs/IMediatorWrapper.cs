using Footballista.Cqrs.Base.Commands;
using Footballista.Cqrs.Base.Queries;
using System.Threading.Tasks;

namespace Footballista.Cqrs
{
    /// <summary>
    /// Wraps the underlying mediator pattern provider.
    /// </summary>
    public interface IMediatorWrapper
    {
        /// <summary>
        /// Dispatch any command of type <see cref="ICommand"/>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task DispatchAsync(ICommand command);

        /// <summary>
        /// Gets a result from a query.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<TResponse> GetResultAsync<TResponse>(IQuery<TResponse> query);
    }
}
