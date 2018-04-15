using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyMatcherLibrary.Tests.Mocks;
using PropertyMatcherLibrary.Factory;
using System.Collections.Generic;
using System.Linq;
using PropertyMatcherLibrary.Rules.Properties;

namespace PropertyMatcherLibrary.Tests
{
    /// <summary>
    /// Test class for ruleset factory
    /// </summary>
    [TestClass]
    public class RulesetFactoryTests
    {
        [TestMethod]
        public void GetPropertyRuleSet_Returns_Right_Rules_For_ABC()
        {
            
            var factory = new RulesetFactory(ruleSet);
            var ruleSets=factory.GetPropertyRuleSet("ABC");
            Assert.IsTrue(ruleSets.Count() == 2);
            Assert.IsTrue(ruleSets.Any(m => m.GetType() == typeof(LocationRule)));
            Assert.IsTrue(ruleSets.Any(m => m.GetType() == typeof(NoPunctuationNameRule)));

        }

        [TestMethod]
        public void GetPropertyRuleSet_Returns_Right_Rules_For_XYZ()
        {

            var factory = new RulesetFactory(ruleSet);
            var ruleSets = factory.GetPropertyRuleSet("XYZ");
            Assert.IsTrue(ruleSets.Count() == 1);
            Assert.IsTrue(ruleSets.Any(m => m.GetType() == typeof(NoPunctuationNameRule)));

        }


        Dictionary<string, IEnumerable<string>> ruleSet = new Dictionary<string, IEnumerable<string>>
            {
                { "ABC",new List<string>{nameof(LocationRule),nameof(NoPunctuationNameRule) } },
                { "XYZ",new List<string>{nameof(NoPunctuationNameRule) } }
            };
    }
}
