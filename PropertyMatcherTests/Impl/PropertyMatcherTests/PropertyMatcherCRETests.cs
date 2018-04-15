using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyMatcherLibrary;
using PropertyMatcherLibrary.Impl;
using PropertyMatcherLibrary.Models;
using PropertyMatcherLibrary.Tests.Mocks;

namespace PropertyMatcherLibrary.Tests
{

    [TestClass]
    public class PropertyMatcherCRETests
    {
        [TestMethod]
        public void IsMatch_Should_Return_True_For_Reverse_Name()
        {
            var source = new Property() { Name = "Apartments Summit The", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "CRE", Latitude = 106.006M, Longitude = 104.006M };
            var compareWIth = new Property() { Name = "The Summit Apartments", Address = "32 Sir John-Young Crescent, Sydney, NSW.s", AgencyCode = "CRE", Latitude = 106.0042072072072M, Longitude = 104.0042072072172M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_True_For_Reverse_Name_2()
        {
            var source = new Property() { Name = "Flat Summit This", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "CRE", Latitude = 106.006M, Longitude = 104.006M };
            var compareWIth = new Property() { Name = "This Summit Flat", Address = "32 Sir John-Young Crescent, Sydney, NSW.s", AgencyCode = "CRE", Latitude = 106.0042072072072M, Longitude = 104.0042072072172M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_False_For_Different_Reverse_Name()
        {
            var source = new Property() { Name = "Flat Summit This", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "CRE", Latitude = 106.006M, Longitude = 104.006M };
            var compareWIth = new Property() { Name = "This Summit Flats", Address = "32 Sir John-Young Crescent, Sydney, NSW.s", AgencyCode = "CRE", Latitude = 106.0042072072072M, Longitude = 104.0042072072172M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsMatch_Should_Return_False_For_Different_Reverse_Name_2()
        {
            var source = new Property() { Name = "Flat Summit This", Address = "32 Sir John-Young Crescent, Sydney, NSW.", AgencyCode = "CRE", Latitude = 106.006M, Longitude = 104.006M };
            var compareWIth = new Property() { Name = "This Summits Flat", Address = "32 Sir John-Young Crescent, Sydney, NSW.s", AgencyCode = "CRE", Latitude = 106.0042072072072M, Longitude = 104.0042072072172M };
            var matcher = new PropertyMatcher();
            var result = matcher.IsMatch(source, compareWIth);
            Assert.IsFalse(result);
        }

    }

}
