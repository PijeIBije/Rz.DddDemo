using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Rz.DddDemo.Base.Mapping.Interface;
using Rz.DddDemo.Customers.Application.Queries.Customer;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Infrastructure.CustomerRepository.MongoDb.Dto;
using Rz.DddDemo.Customers.Infrastructure.Schemas.Database.MongoDb;
using Rz.DddDemo.Base.Infrastructure;
using Rz.DddDemo.Base.Infrastructure.Exceptions;
using Rz.DddDemo.Base.Infrastructure.MongoDb;
using Rz.DddDemo.Customers.Application.Interfaces;

namespace Rz.DddDemo.Customers.Infrastructure.CustomerRepository.MongoDb
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly MongoClient mongoClient;
        private readonly EntityCache entityCache;
        private readonly IncludesToProjectionBsonMapper includesToProjectionBsonMapper;
        private readonly IMapper mapper;

    public CustomerRepository(
        MongoClient mongoClient,
        EntityCache entityCache,
        IncludesToProjectionBsonMapper includesToProjectionBsonMapper,
        MongoSharedTransaction mongoSharedTransaction,
        IMapper mapper)
        {
            this.mongoClient = mongoClient;
            this.entityCache = entityCache;
            this.includesToProjectionBsonMapper = includesToProjectionBsonMapper;
            this.mapper = mapper;
            mongoSharedTransaction.CommitEvent += MongoSharedTransactionCommitEvent;
        }

        protected void MongoSharedTransactionCommitEvent(List<Func<Task>> transactionTasks)
        {
            async Task Task()
            {
                var customerDtos = entityCache.GetToSave<CustomerAggregate>().Select(x => mapper.Map<CustomerAggregate, CustomerDto>(x)).ToList();

                var writeModels = new List<WriteModel<CustomerDto>>();

                foreach (var customerDto in customerDtos)
                {
                    writeModels.Add(new ReplaceOneModel<CustomerDto>(new ExpressionFilterDefinition<CustomerDto>(x => x.Id == customerDto.Id), customerDto) {IsUpsert = true});
                }

                await MongoDb.GetCollection<CustomerDto>(Schema.CustomersCollection)
                    .BulkWriteAsync(writeModels, new BulkWriteOptions {IsOrdered = false});
            }

            transactionTasks.Add(Task);
        }

        private async Task Commit()
        {
            var customerDtos = entityCache.GetToSave<CustomerAggregate>().Select(x=>mapper.Map<CustomerAggregate,CustomerDto>(x)).ToList();

            var writeModels = new List<WriteModel<CustomerDto>>();

            foreach (var customerDto in customerDtos)
            {
                writeModels.Add(
                    new ReplaceOneModel<CustomerDto>(
                            new ExpressionFilterDefinition<CustomerDto>(x => x.Id == customerDto.Id), customerDto)
                        { IsUpsert = true });
            }

            await MongoDb.GetCollection<CustomerDto>(Schema.CustomersCollection)
                .BulkWriteAsync(writeModels, new BulkWriteOptions {IsOrdered = false});
        }

        private IMongoDatabase MongoDb => mongoClient.GetDatabase(Schema.DbName);

        public async Task<CustomerAggregate> GetById(CustomerId customerId)
        {
            var dto = await MongoDb.GetCollection<CustomerDto>(Schema.CustomersCollection)
                .Find(x => x.Id == customerId.Value).SingleOrDefaultAsync();

            if (dto == null) throw new NoResultsException(typeof(CustomerAggregate), customerId);

            return mapper.Map<CustomerDto,CustomerAggregate>(dto);
        }

        public Task Save(CustomerAggregate customerEntity)
        {
            entityCache.AddToSave(customerEntity.Id, customerEntity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<CustomerResult>> Get(CustomerId customerId, CustomerIncludes customerIncludes,CancellationToken cancellationToken)
        {
            var filter = Builders<CustomerDto>.Filter.Empty;

            if (customerId != null)
            {
                filter &= Builders<CustomerDto>.Filter.Where(x => x.Id == customerId.Value);
            }

            var projection = includesToProjectionBsonMapper.Map(customerIncludes, null, null);

            var dtos = await MongoDb.GetCollection<CustomerDto>(Schema.CustomersCollection).Find(filter)
                .Project<CustomerDto>(projection).ToListAsync(cancellationToken);

            return dtos.Select(x=>mapper.Map<CustomerDto,CustomerResult>(x));
        }
    }
}
