using Footballista.BuildingBlocks.Domain.KNNs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.BuildingBlocks.Domain.KNNs
{
	public interface IDistanceMeasurable<T>
	{
		Distance GetDistance(T other);
	}
}
