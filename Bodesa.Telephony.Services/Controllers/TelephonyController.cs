using Bodesa.Telephony.Services.Repository;
using Bodesa.Telephony.Services.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bodesa.Telephony.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelephonyController : Controller
    {
        //private readonly ILogger<TelephonyController> logger;
        private readonly IUnitOfWork unitOfWork;
        Repository.IRepository<Models.cnf_CustomerData> repository;

        public TelephonyController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new CustomerDataRepository(unitOfWork);
        }

     

        //public TelephonyController(ILogger<TelephonyController> logger)
        //{
        //    this.logger = logger;
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.cnf_CustomerData>>> GetCustomer()
        {

           return  await repository.Get();
        }
    }
}

