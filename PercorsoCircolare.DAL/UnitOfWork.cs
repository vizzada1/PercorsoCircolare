using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.ServiceModel;
using System.Threading;

namespace PercorsoCircolare.DAL
{
    public interface IUnitOfWork
    {
        int Commit();
    }

    public static class UnitOfWork
    {
        private static readonly string CONTEXTKEY = "UnitOfWorkContext";
        private static readonly Hashtable _threads = new Hashtable();

        public static IUnitOfWork Current
        {
            get
            {
                var unitOfWork = GetUnitOfWork();

                if (unitOfWork == null)
                {
                    unitOfWork = new EFUnitOfWork(new DALManager());
                    SaveUnitOfWork(unitOfWork);
                }

                return unitOfWork;
            }
        }

        public static void Commit()
        {
            var unitOfWork = GetUnitOfWork();

            if (unitOfWork != null) unitOfWork.Commit();
        }

        private static IUnitOfWork GetUnitOfWork()
        {
            if (OperationContext.Current != null && OperationContext.Current.RequestContext != null)
            {
                if (OperationContext.Current.RequestContext.RequestMessage.Properties.ContainsKey(CONTEXTKEY))
                    return (IUnitOfWork) OperationContext.Current.RequestContext.RequestMessage.Properties[CONTEXTKEY];
                return null;
            }

            var thread = Thread.CurrentThread;
            if (string.IsNullOrEmpty(thread.Name))
            {
                thread.Name = Guid.NewGuid().ToString();
                return null;
            }

            lock (_threads.SyncRoot)
            {
                return (IUnitOfWork) _threads[Thread.CurrentThread.Name];
            }
        }

        private static void SaveUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (OperationContext.Current != null && OperationContext.Current.RequestContext != null)
                OperationContext.Current.RequestContext.RequestMessage.Properties.Add(CONTEXTKEY, unitOfWork);
            else
                lock (_threads.SyncRoot)
                {
                    _threads[Thread.CurrentThread.Name] = unitOfWork;
                }
        }
    }

    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private volatile Type _dependency;

        public EFUnitOfWork(DbContext context)
        {
            // Thanks to this (useless) initialization System.Data.SqlClient will be included in published package
            _dependency = typeof(SqlProviderServices);
            Context = context;
            context.Configuration.LazyLoadingEnabled = true;
        }

        public DbContext Context { get; private set; }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }

            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }
    }
}