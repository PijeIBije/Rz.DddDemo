using MongoDB.Driver;
using Rz.DddDemo.Base.Application.TransactionHandling.Interfaces;

namespace Rz.DddDemo.Base.Infrastructure.MongoDb
{
    public abstract class MongoDbRepositoryBase
    {
        protected EntityCache EntityCache { get; }

        protected readonly MongoClient MongoClient;
        private readonly MongoSharedTransaction mongoSharedTransaction;

        protected MongoDbRepositoryBase(
            MongoClient mongoClient, 
            EntityCache entityCache,
            MongoSharedTransaction mongoSharedTransaction)
        {
            MongoClient = mongoClient;
            this.mongoSharedTransaction = mongoSharedTransaction;
            EntityCache = entityCache;
        }
    }
}
