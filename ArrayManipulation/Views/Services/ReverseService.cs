namespace ArrayManipulation.Services
{
    public interface IReverseService
    {
        int[] ReverseWholeArray(int[] items);
    }

    /// <summary>
    /// Service to reverse an array
    /// </summary>
    public class ReverseService : IReverseService
    {
        /// <summary>
        /// Returns the reversed array.
        /// </summary>
        /// <param name="items">items</param>
        /// <returns>int[]</returns>
        public int[] ReverseWholeArray(int[] items)
        {
            for (var i = 0; i < items.Length / 2; i++)
            {
                // Get the current index value
                var currentIndexValue = items[i];

                // reverses the second half of the array
                items[i] = items[items.Length - i - 1];

                // reverses the first half
                items[items.Length - i - 1] = currentIndexValue; 
            }

            return items;
        }
    }
}