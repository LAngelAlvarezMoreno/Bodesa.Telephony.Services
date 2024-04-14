using Bodesa.Telephony.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Bodesa.Telephony.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationdbContext context;
        private bool disposed = false;

        public UnitOfWork(ApplicationdbContext _context)
        {
            context = _context;
        }

        public ApplicationdbContext Context => context;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
