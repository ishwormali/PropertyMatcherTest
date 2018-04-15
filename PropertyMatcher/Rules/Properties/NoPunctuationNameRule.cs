using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyMatcherLibrary.Models;

namespace PropertyMatcherLibrary.Rules.Properties
{
    /// <summary>
    /// Rule to check for property name regardless of punctuation mark.
    /// </summary>
    [RuleSet(nameof(NoPunctuationNameRule))]
    public class NoPunctuationNameRule : IRule<Property>
    {
        /// <summary>
        /// Tests the rule.
        /// </summary>
        /// <param name="match"></param>
        /// <param name="matchWith"></param>
        /// <returns></returns>
        public bool Test(Property match, Property matchWith)
        {
            return PrimitiveRules.NoPunctuationStringComparer(match.Name, matchWith.Name);
        }
    }
}
