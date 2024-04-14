using Bodesa.Telephony.Services.UnitOfWork;

namespace Bodesa.Telephony.Services.Repository
{
    public class CustomerDataRepository : RepositoryBase<Models.cnf_CustomerData>
    {
        public CustomerDataRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
    }
}
