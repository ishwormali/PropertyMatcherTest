using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyMatcherLibrary.Models;

namespace PropertyMatcherLibrary.Rules.Properties
{
    /// <summary>
    /// Rule to check for location 
    /// </summary>
    [RuleSet(nameof(LocationRule))]
    public class LocationRule : IRule<Property>
    {
        /// <summary>
        /// Test the rule
        /// </summary>
        /// <param name="match"></param>
        /// <param name="matchWith"></param>
        /// <returns></returns>
        public bool Test(Property match, Property matchWith)
        {
            return PrimitiveRules.CloseLocationMatch(match.Latitude, matchWith.Latitude) && PrimitiveRules.CloseLocationMatch(match.Longitude, matchWith.Longitude);
        }
    }
}
