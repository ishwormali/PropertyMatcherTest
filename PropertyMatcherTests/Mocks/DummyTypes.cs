using PropertyMatcherLibrary;
using PropertyMatcherLibrary.Models;
using PropertyMatcherLibrary.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Tests.Mocks
{
    public interface IDummyTypeInterface
    {

         
    }



    public class DummyTypeA:IDummyTypeInterface
    {

    }

    public class DummyTypeB:IDummyTypeInterface
    {

    }

    public class DummyPropertyClass
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    [RuleSetAttribute(nameof(DummyRuleA))]
    public class DummyRuleA : IRule<DummyPropertyClass>
    {
        public bool Test(DummyPropertyClass match, DummyPropertyClass matchWith)
        {
            throw new NotImplementedException();
        }
    }

    [RuleSetAttribute(nameof(DummyRuleB))]
    public class DummyRuleB : IRule<DummyPropertyClass>
    {
        public bool Test(DummyPropertyClass match, DummyPropertyClass matchWith)
        {
            throw new NotImplementedException();
        }
    }
}
