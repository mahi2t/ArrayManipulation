using ArrayManipulation.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArrayManipulation.UnitTests.Services
{
    [TestFixture()]
    public class ReverseServiceTests
    {
        private ReverseService _reverseService;

        [SetUp]
        public void Setup()
        {
            _reverseService = new ReverseService();
        }

        [TestCase(new int[] { 2, 3, 4, }, new int[] { 4, 3, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 10, 3, 25, 0, 7 }, new int[] { 7, 0, 25, 3, 10 })]
        public void ReverseWholeArray_ShouldReverseTheInputArrayAndReturnTheSame(int[] request, int[] expectedResult)
        {
            // Arrange

            // Act
            var actualResult = _reverseService.ReverseWholeArray(request);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
