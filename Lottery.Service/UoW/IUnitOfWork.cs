using System;

namespace Lottery.Service.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
    }
}
