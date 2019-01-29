using ArrayManipulation.Controllers;
using ArrayManipulation.Repository;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace ArrayManipulation.UnitTests.Controllers
{
    [TestFixture]
    public class DefaultControllerTests
    {
        private IArrayManipulationRepository _arrayManipulationRepository;
        private DefaultController _controller;

        [SetUp]
        public void SetUp()
        {
            _arrayManipulationRepository = Substitute.For<IArrayManipulationRepository>();
            _controller = new DefaultController(_arrayManipulationRepository);
        }

        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase("prodId=1",null)]
        [TestCase("productIds=4&productIds=3&productIds=2&productIds=1", new int[] { 1, 2, 3, 4 })]
        [TestCase("productIds=1&productIds=2&productIds=3&productIds=4&productIds=5", new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        public void ReverseArrayItems_ShouldReturnReversedArrayOfItems(string requestParams, int[] expectedResult)
        {
            // Arrange
            _controller.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57313/api/arraycalc/reverse?" + requestParams);
            _arrayManipulationRepository.ReverseArray(Arg.Any<IEnumerable<KeyValuePair<string, string>>>())
                .Returns(expectedResult);

            // Act
            var actualResult = _controller.ReverseArrayItems();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase("prodId=1", null)]
        [TestCase("position=1", null)]
        [TestCase("position=2&productIds=4&productIds=3&productIds=2&productIds=1", new int[] { 4, 2, 1 })]
        [TestCase("position=10&productIds=1&productIds=2&productIds=3&productIds=4&productIds=5", new int[] { 1, 2, 3, 4, 5 })]
        public void DeleteItemFromArrayItems_ShouldDeleteRequestedItemAndReturnRemainingItems(string requestParams, int[] expectedResult)
        {
            // Arrange
            _controller.Request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:57313/api/arraycalc/deletepart?" + requestParams);
            _arrayManipulationRepository.DeleteItemFromArray(Arg.Any<IEnumerable<KeyValuePair<string, string>>>())
                .Returns(expectedResult);

            // Act
            var actualResult = _controller.DeleteItemFromArrayItems();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
