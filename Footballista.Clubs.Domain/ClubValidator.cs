using FluentValidation;

namespace Footballista.Clubs.Domain
{
	public class ClubValidator : AbstractValidator<Club>
	{
		public ClubValidator()
		{
			RuleFor(c => c.Name).NotEmpty();

			RuleFor(c => c.YearOfCreation).NotEmpty().GreaterThan(1800);
		}
	}
}
