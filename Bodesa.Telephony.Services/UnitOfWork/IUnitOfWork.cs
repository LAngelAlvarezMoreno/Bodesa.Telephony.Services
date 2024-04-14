using Bodesa.Telephony.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Bodesa.Telephony.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationdbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
