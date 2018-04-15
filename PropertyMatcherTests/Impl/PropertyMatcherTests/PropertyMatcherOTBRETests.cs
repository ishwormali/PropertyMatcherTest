using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyMatcherLibrary.Impl;
using PropertyMatcherLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherTests.Impl.PropertyMatcherTests
{
    [TestClass]
    public class PropertyMatcherOTBRETests
    {
        [TestMethod]
        public void IsMatch_Should_Return_True_For_Punctuation()
        {
            var source = new Property() { Name = "*Super*-High! APARTMENTS (Sydney)", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "OTBRE", Latitude = 100, Longitude = 105 };
            var compareWIth = new Property() { Name = "*Super High Apartments, Sydney", Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "OTBRE", Latitude = 1003, Longitude = 1045 };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_For_For_Different_Address()
        {
            var source = new Property() { Name = "*Super*-High! APARTMENTS (Sydney)", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "OTBRE", Latitude = 100, Longitude = 105 };
            var compareWIth = new Property() { Name = "*Super High Apartments, Sydney", Address = "32 Sir John Young Crescent, Sydney NSWs", AgencyCode = "OTBRE", Latitude = 1003, Longitude = 1045 };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_For_For_Different_Name()
        {
            var source = new Property() { Name = "*Super*-High! APARTMENTS (Sydney)", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "OTBRE", Latitude = 100, Longitude = 105 };
            var compareWIth = new Property() { Name = "*Super High Apartments, Sydneys", Address = "32 Sir John Young Crescent, Sydney NSW", AgencyCode = "OTBRE", Latitude = 1003, Longitude = 1045 };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsFalse(result);
        }
    }
}
