using System.Collections.Generic;

namespace Footballista.BuildingBlocks.Domain
{
    /// <summary>
    /// An abstract class representing an entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Enforces a rule or throws a <see cref="BusinessRuleValidationException"/> if the rule is violated.
        /// </summary>
        /// <param name="rule">The business rule to enforce.</param>
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
