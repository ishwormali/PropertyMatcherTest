using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyMatcherLibrary.Models;

namespace PropertyMatcherLibrary.Rules.Properties
{
    /// <summary>
    /// Rule to check if two property matches based on address regardless of puncuation mark.
    /// </summary>
    [RuleSet(nameof(NoPunctuationAddressRule))]
    public class NoPunctuationAddressRule : IRule<Property>
    {
        public bool Test(Property match, Property matchWith)
        {
            return PrimitiveRules.NoPunctuationStringComparer(match.Address, matchWith.Address);
        }
    }
}
