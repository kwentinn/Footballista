using System;

namespace Footballista.Players.Units.Converters
{
	public class AbstractConverter<TFrom, TTo> : IConverter<TFrom, TTo>
		where TFrom : BaseUnit, new()
		where TTo : BaseUnit, new()
	{
		private double _convertCoefficient;
		private double _convertBackCoefficient;

		public AbstractConverter(double coefficientFrom, double coefficientTo)
		{
			_convertCoefficient = coefficientFrom;
			_convertBackCoefficient = coefficientTo;
		}

		public TTo Convert(TFrom from)
		{
			if (from is null) throw new ArgumentNullException(nameof(from));

			var to = new TTo();
			to.Value = from.Value * _convertCoefficient;
			return to;
		}

		public TFrom ConvertBack(TTo to)
		{
			if (to is null) throw new ArgumentNullException(nameof(to));

			var from = new TFrom();
			from.Value = to.Value * _convertBackCoefficient;
			return from;
		}
	}
}
