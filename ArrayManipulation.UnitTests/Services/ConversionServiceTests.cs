using ArrayManipulation.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace ArrayManipulation.UnitTests.Services
{
    [TestFixture()]
    public class ConversionServiceTests
    {
        private ConversionService _conversionService;

        [SetUp]
        public void Setup()
        {
            _conversionService = new ConversionService();
        }
  
        [TestCase("ProductIds", new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase("SomeThingElse", new int[] { })]
        public void GetProductIdsArrayFromRequest1_ShouldReturnArrayItemsIfTheRequestHasValidKey(string key, int[] expectedResult)
        {
            // Arrange
            var requestParams = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>(key, "1"),
                new KeyValuePair<string, string>(key, "2"),
                new KeyValuePair<string, string>(key, "3"),
                new KeyValuePair<string, string>(key, "4"),
                new KeyValuePair<string, string>(key, "5"),
                new KeyValuePair<string, string>(key, "6"),
            };

            // Act
            var actualResult = _conversionService.GetProductIdsArrayBasedOnRequest(requestParams, "productids", out _, null);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("ProductIds", new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase("SomeThingElse", new int[] { })]
        public void GetProductIdsArrayFromRequest_ShouldTheArrayAlongWithPosition(string key, int[] expectedResult)
        {
            // Arrange
            var requestParams = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>(key, "1"),
                new KeyValuePair<string, string>(key, "2"),
                new KeyValuePair<string, string>(key, "3"),
                new KeyValuePair<string, string>(key, "4"),
                new KeyValuePair<string, string>(key, "5"),
                new KeyValuePair<string, string>(key, "6"),
                new KeyValuePair<string, string>("position", "3"),
            };

            // Act
            var actualResult = _conversionService.GetProductIdsArrayBasedOnRequest(requestParams,
                "productids", out var position, "position");

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(3, position);
        }
    }
}
