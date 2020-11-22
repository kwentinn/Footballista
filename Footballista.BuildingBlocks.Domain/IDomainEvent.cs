using MediatR;
using System;

namespace Footballista.BuildingBlocks.Domain
{
	public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }

}
