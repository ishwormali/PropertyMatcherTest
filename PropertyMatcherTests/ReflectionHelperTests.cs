using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyMatcherLibrary.Helpers;
using PropertyMatcherLibrary.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using PropertyMatcherLibrary;

namespace PropertyMatcherLibrary.Tests
{
    [TestClass]
    public class ReflectionHelperTests
    {

        [TestMethod]
        public void GetClassOfType_Should_Returns_Right_Types()
        {
            var result = ReflectionHelpers.GetClassOfType<IDummyTypeInterface>();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 2, "Should have 2 types implementing IDummyTypeInterface");
            Assert.IsTrue(result.Any(m => m == typeof(DummyTypeA)), "Should have type DummyTypeA implementing IDummyTypeInterface");
            Assert.IsTrue(result.Any(m => m == typeof(DummyTypeB)), "Should have type DummyTypeB implementing IDummyTypeInterface");
        }

        [TestMethod]
        public void FindRulesByNames_Should_Return_Right_Rules()
        {
            string[] ruleNames = { nameof(DummyRuleA), nameof(DummyRuleB) };

            var rules = ReflectionHelpers.FindRulesByNames<DummyPropertyClass>(ruleNames);
            Assert.IsTrue(rules.Count() == 2);
            Assert.IsTrue(rules.Any(m => m.GetType() == typeof(DummyRuleA)));
            Assert.IsTrue(rules.Any(m => m.GetType() == typeof(DummyRuleB)));

        }
    }
}
