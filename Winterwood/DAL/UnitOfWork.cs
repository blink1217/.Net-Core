using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winterwood.Models; 

namespace Winterwood.DAL
{
    public class UnitOfWork: IDisposable
    {
        private WinterwoodContext context = new WinterwoodContext();
        private GenericRepository<Account> accountRepository;
        private GenericRepository<Invoice> invoiceRepository;

        public GenericRepository<Account> AccountRepository {
            get {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<Account>(context);
                }
                return accountRepository;
            }
        }

        public GenericRepository<Invoice> InvoiceRepository {
            get {

                if (this.invoiceRepository == null)
                {
                    this.invoiceRepository = new GenericRepository<Invoice>(context);
                }
                return invoiceRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
