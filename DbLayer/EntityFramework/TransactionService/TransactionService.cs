using ModelsLayer.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.EntityFramework.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private UnitOfWork _unitOfWork;
        public TransactionService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public bool CommitTransaction()
        {
            try
            {
                this._unitOfWork.Database.CommitTransaction();
                return true;
            }
            catch(Exception ex)
            {
                //Log
                return false;
            }
        }

        public void OpenTransaction()
        {
            this._unitOfWork.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            this._unitOfWork.Database.RollbackTransaction();
        }
    }
}
