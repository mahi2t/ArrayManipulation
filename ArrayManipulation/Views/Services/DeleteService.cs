using System;

namespace ArrayManipulation.Services
{
    public interface IDeleteService
    {
        int[] DeleteItemFromArrayBasedOnPosition(int[] items, int position);
    }

    public class DeleteService : IDeleteService
    {
        /// <summary>
        /// Returns the array list after deleting the requested item based on position.
        /// </summary>
        /// <param name="items">items</param>
        /// <param name="position">position</param>
        /// <returns>int[]</returns>
        public int[] DeleteItemFromArrayBasedOnPosition(int[] items, int position)
        {
            // if the position of the item to delete is invalid then return the input array list.
            if (position <= 0 || position > items.Length)
            {
                return items;
            }

            // delete the item
            for (var i = position - 1; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }

            // last item repeats so resize to remove the duplicate
            Array.Resize(ref items, items.Length - 1);
            return items;
        }
    }
}