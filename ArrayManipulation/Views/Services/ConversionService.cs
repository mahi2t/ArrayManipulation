using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace ArrayManipulation.Services
{
    public interface IConversionService
    {
        int[] GetProductIdsArrayBasedOnRequest(IEnumerable<KeyValuePair<string, string>> queryParamsList, string queryParam1,
            out int position, string queryParam2 = null);
    }

    /// <summary>
    /// ConversionService
    /// </summary>
    public class ConversionService : IConversionService
    {
        /// <summary>
        /// Converts the input request to integer array.
        /// </summary>
        /// <param name="queryParamsList">queryParamsList</param>
        /// <param name="queryParam1">queryParam1</param>
        /// <param name="position">position</param>
        /// <param name="queryParam2">queryParam2</param>
        /// <returns>int[]</returns>
        public int[] GetProductIdsArrayBasedOnRequest(IEnumerable<KeyValuePair<string, string>> queryParamsList, string queryParam1, out int position, string queryParam2 = null)
        {
            position = -1;
            var inputParamList = queryParamsList as KeyValuePair<string, string>[] ?? queryParamsList.ToArray();
            var positionArray = inputParamList.Where(x => x.Key.ToLower().Equals(queryParam1)).Select(x => x.Value.AsInt()).ToArray();
            if (!string.IsNullOrWhiteSpace(queryParam2))
            {
                position = inputParamList.Where(x => x.Key.ToLower().Equals(queryParam2)).Select(x => x.Value.AsInt()).FirstOrDefault();
            }

            return positionArray;
        }
    }

}