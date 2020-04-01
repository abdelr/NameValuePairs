using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NameValuePairs.Core.Constraints;
using NameValuePairs.Core.Entities;
using NameValuePairs.Test;
using NameValuePairs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NameValuePairs.Repositories.Test
{
    [TestClass]
    public class NameValuePairRepositoryTests : TestBase
    {
        [TestMethod]
        public void NameValuePairRepository_MatchesConstraintWhenAddingPair()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            var target = new NameValuePairRepository(mockDependency.Object);
            var pair = new NameValuePair
            {
                Name = RandomGenerator.RandomString(),
                Value = RandomGenerator.RandomString()
            };

            target.Add(pair);
            mockDependency.Verify(x => x.Match(pair), Times.Once);
        }

        private Func<NameValuePair, NameValuePair> passThrough = pair => pair;

        [TestMethod]
        public void NameValuePairRepository_List()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            mockDependency.Setup(x => x.Match(It.IsAny<NameValuePair>())).Returns(passThrough);
            var target = new NameValuePairRepository(mockDependency.Object);
            var total = RandomGenerator.Random.Next(5, 10);
            var pairs = new List<NameValuePair>();
            for (var i = 0; i < total; i++)
            {
                var pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                target.Add(pair);
                pairs.Add(pair);
            }

            var list = target.List() as List<NameValuePair>;
            CollectionAssert.AreEqual(pairs, list);
        }

        [TestMethod]
        public void NameValuePairRepository_DeleteRange()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            mockDependency.Setup(x => x.Match(It.IsAny<NameValuePair>())).Returns(passThrough);
            var target = new NameValuePairRepository(mockDependency.Object);
            var total = RandomGenerator.Random.Next(5, 10);
            var pairsDeleted = new List<NameValuePair>();
            var pairsKept = new List<NameValuePair>();
            for (var i = 0; i < total; i++)
            {
                var pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                target.Add(pair);
                if (RandomGenerator.RandomBoolean(0.5))
                    pairsDeleted.Add(pair);
                else
                    pairsKept.Add(pair);
            }

            target.RemoveRange(pairsDeleted);
            var list = target.List() as List<NameValuePair>;
            CollectionAssert.AreEqual(pairsKept, list);
        }

        [TestMethod]
        public void NameValuePairRepository_FilterOnName()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            mockDependency.Setup(x => x.Match(It.IsAny<NameValuePair>())).Returns(passThrough);
            var target = new NameValuePairRepository(mockDependency.Object);
            var total = RandomGenerator.Random.Next(5, 10);
            var pairsFiltered = new List<NameValuePair>();
            var mark = "FILTERED";
            for (var i = 0; i < total; i++)
            {
                var pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString() + mark + RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                target.Add(pair);
                pairsFiltered.Add(pair);

                pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                while (pair.Name.Contains(mark))
                    pair = new NameValuePair
                    {
                        Name = RandomGenerator.RandomString(),
                        Value = RandomGenerator.RandomString()
                    };
                target.Add(pair);
            }

            var list = target.Filter(new FilterSetting
            {
                Type = FilterSetting.ValueType.NAME,
                Value = mark
            }) as List<NameValuePair>;
            CollectionAssert.AreEqual(pairsFiltered, list);
        }

        [TestMethod]
        public void NameValuePairRepository_FilterOnValue()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            mockDependency.Setup(x => x.Match(It.IsAny<NameValuePair>())).Returns(passThrough);
            var target = new NameValuePairRepository(mockDependency.Object);
            var total = RandomGenerator.Random.Next(5, 10);
            var pairsFiltered = new List<NameValuePair>();
            var mark = "FILTERED";
            for (var i = 0; i < total; i++)
            {
                var pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString() + mark + RandomGenerator.RandomString()
                };
                target.Add(pair);
                pairsFiltered.Add(pair);

                pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                while (pair.Value.Contains(mark))
                    pair = new NameValuePair
                    {
                        Name = RandomGenerator.RandomString(),
                        Value = RandomGenerator.RandomString()
                    };
                target.Add(pair);
            }

            var list = target.Filter(new FilterSetting
            {
                Type = FilterSetting.ValueType.VALUE,
                Value = mark
            }) as List<NameValuePair>;
            CollectionAssert.AreEqual(pairsFiltered, list);
        }

        [TestMethod]
        public void NameValuePairRepository_SortByName()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            mockDependency.Setup(x => x.Match(It.IsAny<NameValuePair>())).Returns(passThrough);
            var target = new NameValuePairRepository(mockDependency.Object);
            var total = RandomGenerator.Random.Next(5, 10);
            var pairs = new List<NameValuePair>();
            for (var i = 0; i < total; i++)
            {
                var pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                target.Add(pair);
                pairs.Add(pair);
            }

            var list = target.SortByName() as List<NameValuePair>;
            CollectionAssert.AreEqual(pairs.OrderBy(item => item.Name).ToList(), list);
        }

        [TestMethod]
        public void NameValuePairRepository_SortByValue()
        {
            var mockDependency = new Mock<INameValuePairConstraints>();
            mockDependency.Setup(x => x.Match(It.IsAny<NameValuePair>())).Returns(passThrough);
            var target = new NameValuePairRepository(mockDependency.Object);
            var total = RandomGenerator.Random.Next(5, 10);
            var pairs = new List<NameValuePair>();
            for (var i = 0; i < total; i++)
            {
                var pair = new NameValuePair
                {
                    Name = RandomGenerator.RandomString(),
                    Value = RandomGenerator.RandomString()
                };
                target.Add(pair);
                pairs.Add(pair);
            }

            var list = target.SortByValue() as List<NameValuePair>;
            CollectionAssert.AreEqual(pairs.OrderBy(item => item.Value).ToList(), list);
        }
    }
}
