using Bodesa.Telephony.Services.UnitOfWork;

namespace Bodesa.Telephony.Services.Repository
{
    public class VendorRepository : RepositoryBase<Models.Cnf_Vendors>
    {
        public VendorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
                
        }
    }
}
