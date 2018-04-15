using PropertyMatcherLibrary;
using PropertyMatcherLibrary.Helpers;
using PropertyMatcherLibrary.Models;
using PropertyMatcherLibrary.Rules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Factory
{
    /// <summary>
    /// Factory class to get comparer
    /// </summary>
    public class RulesetFactory:IRulesetFactory
    {

        public RulesetFactory(IDictionary<string,IEnumerable<string>> rules)
        {
            propertyRules = rules??new Dictionary<string,IEnumerable<string>>();

        }
        /// <summary>
        /// Gets an instance of <see cref="IPropertyComparer"/>  based on agency code
        /// </summary>
        /// <param name="agencyCode">Agency code</param>
        /// <returns><see cref="IPropertyComparer"/></returns>
        public IEnumerable<IRule<Property>> GetPropertyRuleSet(string agencyCode)
        {
            //Check if rule has been defined for this agency code
            var rulePack = propertyRules.FirstOrDefault(m => string.Equals(m.Key, agencyCode, StringComparison.OrdinalIgnoreCase));
            
            if(rulePack.Value!=null) //If ruleset has been defined for the agency code
            {
                
                var rules=ReflectionHelpers.FindRulesByNames<Property>(rulePack.Value.ToArray());
                return rules;
                
            }
            else
            {
                //No rule has been defined for the agency code.
                return new List<IRule<Property>>();
            }
            
        }

        private static IDictionary<string, IEnumerable<string>> propertyRules;

    }
}
