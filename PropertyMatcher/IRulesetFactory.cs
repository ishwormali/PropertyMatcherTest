using PropertyMatcherLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary
{
    /// <summary>
    /// Contract for ruleset factory
    /// </summary>
    public interface IRulesetFactory
    {
        /// <summary>
        /// Gets sets of ruleset for the given agency code
        /// </summary>
        /// <param name="agencyCode"></param>
        /// <returns></returns>
        IEnumerable<IRule<Property>> GetPropertyRuleSet(string agencyCode);
    }
}
