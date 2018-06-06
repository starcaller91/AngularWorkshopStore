using Data;
using Model.Core;
using Model.Domain;
using System.Linq;
using System.Web.Http;

namespace AngularWorkshop.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private readonly IRepository<Customer> _customerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork, IRepository<Customer> customerRepo)
        {
            _unitOfWork = unitOfWork;
            _customerRepo = customerRepo;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLIst()
        {
            return Ok(_customerRepo.Items.ToList());
        }
    }
}
