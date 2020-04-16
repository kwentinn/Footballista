using Microsoft.Extensions.Hosting;

namespace Footballista.Players.Infrastracture.Loaders.Growths
{
	public class WeightGrowthRecordLoader : AbstractGrowthRecordsLoader, IWeightGrowthRecordLoader
	{
		public override string FilePathForMale => @"Weight-for-age-Male-2-to-20-years.csv";
		public override string FilePathForFemale => @"Weight-for-age-Female-2-to-20-years.csv";

		public WeightGrowthRecordLoader(IHostEnvironment hostEnvironment) : base(hostEnvironment) { }
	}
}

