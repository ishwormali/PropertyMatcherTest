using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyMatcherLibrary;
using PropertyMatcherLibrary.Impl;
using PropertyMatcherLibrary.Models;
using PropertyMatcherLibrary.Tests.Mocks;

namespace PropertyMatcherLibrary.Tests
{

    [TestClass]
    public class PropertyMatcherLRETests
    {
        [TestMethod]
        public void IsMatch_Should_Return_True_For_Same_Agency_Within_200M()
        {
            var source = new Property() { Name = "Super High Apartments, Sydney", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "LRE", Latitude = 106.006M, Longitude = 104.006M };
            var compareWIth = new Property() { Name = "Super High Apartments, Sydneys", Address = "32 Sir John-Young Crescent, Sydney, NSW.s", AgencyCode = "LRE", Latitude = 106.0042072072072M, Longitude = 104.0042072072172M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_False_For_Different_Agency_Within_200M()
        {
            var source = new Property() { Name = "*Super*-High! APARTMENTS (Sydney)", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "LRE", Latitude = 106.006M, Longitude = 104.006M };
            var compareWIth = new Property() { Name = "*Super High Apartments, Sydney", Address = "32 Sir John Young Crescent, Sydney NSWs", AgencyCode = "LREA", Latitude = 106.006M, Longitude = 104.006M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_False_For_Same_Agency_Over_200M()
        {
            var source = new Property() { Name = "Super High Apartments, Sydney", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "LRE", Latitude = 106.006M, Longitude = 106.006M };
            var compareWIth = new Property() { Name = "Super High Apartments, Sydneys", Address = "32 Sir John-Young Crescent, Sydney, NSW.s", AgencyCode = "LRE", Latitude = 106.0078108108108M, Longitude = 106.0078108108108M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsFalse(result);
        }
    }

}
