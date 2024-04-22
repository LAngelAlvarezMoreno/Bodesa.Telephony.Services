using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bodesa.Telephony.Services.Context
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
        {

        }

        public DbSet<Models.cnf_CustomerData> cnf_CustomerData { get; set; }

        public DbSet<Models.cnf_PhoneNumber> cnf_PhoneNumber { get; set; }
     
    }
}
