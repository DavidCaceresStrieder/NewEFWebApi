using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.EntityFramework.TransactionService
{
    public interface ITransactionService
    {
        void OpenTransaction();
        bool CommitTransaction();
        void RollbackTransaction();

    }
}
