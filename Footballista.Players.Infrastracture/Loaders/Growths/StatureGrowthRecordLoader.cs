using Microsoft.Extensions.Hosting;

namespace Footballista.Players.Infrastracture.Loaders.Growths
{
	public class StatureGrowthRecordLoader : AbstractGrowthRecordsLoader, IStatureGrowthRecordLoader
	{
		public override string FilePathForMale => @"Stature-for-age-Male-2-to-20-years.csv";
		public override string FilePathForFemale => @"Stature-for-age-Female-2-to-20-years.csv";

		public StatureGrowthRecordLoader(IHostEnvironment hostEnvironment) : base(hostEnvironment) { }
	}
}

