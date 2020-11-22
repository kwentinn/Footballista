using System.Collections.Generic;

namespace Footballista.BlazorServer.Data.Mappers
{
	public interface IMapper<in TSource, out TDestination>
	{
		TDestination Map(TSource objectToMapFrom);
		IEnumerable<TDestination> Map(IEnumerable<TSource> collectionToMapFrom);
	}
}
