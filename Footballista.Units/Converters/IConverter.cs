namespace Footballista.Units.Converters
{
	public interface IConverter<TBaseUnitFrom, TBaseUnitTo>
		where TBaseUnitFrom : BaseUnit, new()
		where TBaseUnitTo : BaseUnit, new()
	{
		TBaseUnitTo Convert(TBaseUnitFrom from);
		TBaseUnitFrom ConvertBack(TBaseUnitTo to);
	}
}
