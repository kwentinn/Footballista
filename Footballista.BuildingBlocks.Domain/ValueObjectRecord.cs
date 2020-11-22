namespace Footballista.BuildingBlocks.Domain
{
    public abstract record ValueObjectRecord
    {
		protected static void CheckRule(IBusinessRule rule)
		{
			if (rule.IsBroken())
			{
				throw new BusinessRuleValidationException(rule);
			}
		}
	}
}
