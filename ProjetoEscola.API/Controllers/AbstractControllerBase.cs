using Microsoft.AspNetCore.Mvc;
using System.Transactions;
namespace ProjetoEscola.API.Controllers
{
    [Produces("application/json")]
    public class AbstractControllerBase : ControllerBase, IDisposable
    {
        private readonly TransactionScope transactionScope;
        private bool disposedValue = false;

        public AbstractControllerBase()
        {
            transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }, TransactionScopeAsyncFlowOption.Enabled);
        }

        protected void Commit()
        {
            transactionScope.Complete();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    transactionScope.Dispose();
                }

                disposedValue = true;
            }
        }

        ////  TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //  ~AbstractControllerBase()
        // {
        //     // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //     Dispose(false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
