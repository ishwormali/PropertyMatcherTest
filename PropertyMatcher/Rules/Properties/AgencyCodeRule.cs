﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyMatcherLibrary.Models;

namespace PropertyMatcherLibrary.Rules.Properties
{
    /// <summary>
    /// Rule to compare agency code.
    /// </summary>
    [RuleSet(nameof(AgencyCodeRule))]
    public class AgencyCodeRule : IRule<Property>
    {
        /// <summary>
        /// Tests the rule.
        /// </summary>
        /// <param name="match"></param>
        /// <param name="matchWith"></param>
        /// <returns></returns>
        public bool Test(Property match, Property matchWith)
        {
            return string.Equals(match.AgencyCode, matchWith.AgencyCode);
        }
    }
}
