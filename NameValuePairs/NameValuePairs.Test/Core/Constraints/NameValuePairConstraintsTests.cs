using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameValuePairs.Core.Entities;
using NameValuePairs.Exceptions;
using NameValuePairs.Test;
using NameValuePairs.Utils;

namespace NameValuePairs.Core.Constraints.Test
{
    [TestClass]
    public class NameValuePairConstraintsTests : TestBase
    {
        [TestMethod]
        public void Match_PassesOnCorrectValues()
        {
            var target = new NameValuePairConstraints();

            var pair = new NameValuePair { Name = RandomGenerator.RandomString(), Value = RandomGenerator.RandomString() };
            Assert.AreEqual(pair, target.Match(pair));
        }

        [TestMethod]
        public void Match_ThrowsOnIncorrectName()
        {
            var target = new NameValuePairConstraints();

            var pair = new NameValuePair
            {
                Name = RandomGenerator.RandomStringExtended(),
                Value = RandomGenerator.RandomString()
            };
            Assert.ThrowsException<NameException>(() => target.Match(pair));
        }

        [TestMethod]
        public void Match_ThrowsOnIncorrectValue()
        {
            var target = new NameValuePairConstraints();

            var pair = new NameValuePair
            {
                Name = RandomGenerator.RandomString(),
                Value = RandomGenerator.RandomStringExtended()
            };
            Assert.ThrowsException<ValueException>(() => target.Match(pair));
        }
    }
}
