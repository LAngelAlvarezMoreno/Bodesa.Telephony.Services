using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bodesa.Telephony.Services.Context
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
        {

        }

        //protected readonly IConfiguration configuration;
        //public ApplicationdbContext(IConfiguration _configuration)
        //{
        //    configuration = _configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionSting = configuration.GetConnectionString("dbConnection");
        //    options.UseSqlServer(connectionSting);
        //}

        public DbSet<Models.cnf_CustomerData> CustomerData { get; set; }
    }
}
