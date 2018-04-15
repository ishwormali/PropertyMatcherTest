using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyMatcherLibrary.Models;
using PropertyMatcherLibrary.Factory;

namespace PropertyMatcherLibrary.Impl
{
    /// <summary>
    /// A class to match property
    /// </summary>
    public class PropertyMatcher : IPropertyMatcher
    {

        private IRulesetFactory propertyRulesetFactory = new RulesetFactory(Constants.PredefinedAgentPropertyRules);

        /// <summary>
        /// Matches agency property vs existing property stored in the db.
        /// </summary>
        /// <param name="agencyProperty">Agency Property</param>
        /// <param name="databaseProperty">Existing db property</param>
        /// <returns></returns>
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var rules = propertyRulesetFactory.GetPropertyRuleSet(agencyProperty.AgencyCode);
            if(!rules.Any())
            {
                return false;
            }
            else
            {
                foreach (var rule in rules)
                {
                    var ruleResult = rule.Test(agencyProperty, databaseProperty);
                    if(!ruleResult)
                    {
                        return false;
                    }
                }

                return true;
            }
            
        }
    }
}
