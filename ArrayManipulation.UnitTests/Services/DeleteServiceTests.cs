using ArrayManipulation.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArrayManipulation.UnitTests.Services
{
    [TestFixture()]
    public class DeleteServiceTests
    {
        private DeleteService _deleteService;

        [SetUp]
        public void Setup()
        {
            _deleteService = new DeleteService();
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 4 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, }, new int[] { 2, 3, 4 })]
        [TestCase(10, new int[] { 1, 2, 3, 4, }, new int[] { 1, 2, 3, 4 })]
        public void DeleteItemFromArrayBasedOnPosition_ShouldDeleteIfValidPositionAndReturnRemainingItems(int position, int[] request, int[] expectedResult)
        {
            // Arrange
            
            // Act
            var actualResult = _deleteService.DeleteItemFromArrayBasedOnPosition(request, position);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
