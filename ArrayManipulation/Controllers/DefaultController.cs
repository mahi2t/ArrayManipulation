using System.Net.Http;
using System.Web.Http;
using ArrayManipulation.Repository;

namespace ArrayManipulation.Controllers
{
    [RoutePrefix("api/arraycalc")]
    public class DefaultController : ApiController
    {
        private readonly IArrayManipulationRepository _arrayManipulationRepository;
        public DefaultController(IArrayManipulationRepository arrayManipulationRepository)
        {
            _arrayManipulationRepository = arrayManipulationRepository;
        }

        [Route("reverse")]
        [HttpGet]
        public int[] ReverseArrayItems()
        {
            return Request != null ? _arrayManipulationRepository.ReverseArray(Request.GetQueryNameValuePairs()) : null;
        }

        [Route("deletepart")]
        [HttpDelete]
        public int[] DeleteItemFromArrayItems()
        {
            return Request != null ? _arrayManipulationRepository.DeleteItemFromArray(Request.GetQueryNameValuePairs()) : null;
        }
    }
}
