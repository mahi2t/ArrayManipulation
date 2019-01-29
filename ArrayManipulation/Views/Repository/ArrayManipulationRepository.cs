using ArrayManipulation.Services;
using System.Collections.Generic;

namespace ArrayManipulation.Repository
{
    public interface IArrayManipulationRepository
    {
        int[] ReverseArray(IEnumerable<KeyValuePair<string, string>> requestParams);
        int[] DeleteItemFromArray(IEnumerable<KeyValuePair<string, string>> requestParams);
    }

    /// <summary>
    /// ArrayManipulationRepository
    /// </summary>
    public class ArrayManipulationRepository : IArrayManipulationRepository
    {
        private const string ProductIdsValue = "productids";
        private readonly IDeleteService _deleteService;
        private readonly IReverseService _reverseService;
        private readonly IConversionService _conversionService;

        public ArrayManipulationRepository(IDeleteService deleteService,
            IReverseService reverseService,
            IConversionService conversionService)
        {
            _deleteService = deleteService;
            _reverseService = reverseService;
            _conversionService = conversionService;
        }

        /// <summary>
        /// Returns the list of reversed items in the array.
        /// </summary>
        /// <param name="requestParams">requestParams</param>
        /// <returns>int[]</returns>
        public int[] ReverseArray(IEnumerable<KeyValuePair<string, string>> requestParams)
        {
            var productIdsArray = _conversionService.GetProductIdsArrayBasedOnRequest(requestParams, ProductIdsValue, out var index);
            if (productIdsArray == null)
            {
                return null;
            }

            var result = _reverseService.ReverseWholeArray(productIdsArray);
            return result;
        }

        /// <summary>
        /// Returns the items remaining in the list.
        /// </summary>
        /// <param name="requestParams">requestParams</param>
        /// <returns>int[]</returns>
        public int[] DeleteItemFromArray(IEnumerable<KeyValuePair<string, string>> requestParams)
        {
            var productIdsArray = _conversionService.GetProductIdsArrayBasedOnRequest(requestParams, ProductIdsValue, out var index);
            if (productIdsArray == null)
            {
                return null;
            }

            var result = _deleteService.DeleteItemFromArrayBasedOnPosition(productIdsArray, index);
            return result;
        }
    }
}