using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyMatcherLibrary.Rules;

namespace PropertyMatcherLibrary.Tests
{
    [TestClass]
    public class PrimitiveRuleTests
    {

        [TestClass]
        public class NoPunctuationStringComparer_Tests
        {
            [TestMethod]
            public void NoPunctuationStringComparer_Should_Return_True()
            {
                string source = "*Super*-High! APARTMENTS (Sydney)";
                string compareWith="Super High Apartments, Sydney";
                var result=PrimitiveRules.NoPunctuationStringComparer(source, compareWith);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void NoPunctuationStringComparer_Should_Return_True_For_Dash()
            {
                string source = "32 Sir John-Young Crescent, Sydney, NSW.";
                string compareWith = "32 Sir John Young Crescent, Sydney NSW";
                var result = PrimitiveRules.NoPunctuationStringComparer(source, compareWith);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void NoPunctuationStringComparer_Should_Return_False()
            {
                string source = "*SuperHigh! APARTMENTS (Sydney)";
                string compareWith = "Super High Apartments, Sydney";
                var result = PrimitiveRules.NoPunctuationStringComparer(source, compareWith);
                Assert.IsFalse(result);
            }

        }

        [TestClass]
        public class CloseLocationMatch_Tests
        {
            [TestMethod]
            public void CloseLocationMatch_Should_Return_True_Within_200_mtr()
            {
                decimal source = 106.006M;
                decimal compareWith = 106.0042072072072M;
                var result=PrimitiveRules.CloseLocationMatch(source, compareWith);
                Assert.IsTrue(result);


            }

            [TestMethod]
            public void CloseLocationMatch_Should_Return_False_Over_200_mtr()
            {
                decimal source = 106.006M;
                decimal compareWith = 106.0078108108108M;
                var result = PrimitiveRules.CloseLocationMatch(source, compareWith);
                Assert.IsFalse(result);


            }
        }


        [TestClass]
        public class ReverseWordsMatch_Tests
        {
            [TestMethod]
            public void ReverseWordsMatch_Should_Return_True_For_Match()
            {
                string source = "Apartments Summit The";
                string compareWith = "The Summit Apartments";
                var result = PrimitiveRules.ReverseWordsMatch(source, compareWith);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ReverseWordsMatch_Should_Return_False_For_Non_Match()
            {
                string source = "Apartments Summit This";
                string compareWith = "The Summit Apartments";
                var result = PrimitiveRules.ReverseWordsMatch(source, compareWith);
                Assert.IsFalse(result);
            }
        }
    }
}
