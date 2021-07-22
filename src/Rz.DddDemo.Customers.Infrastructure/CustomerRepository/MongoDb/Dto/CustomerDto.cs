using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Rz.DddDemo.Customers.Infrastructure.CustomerRepository.MongoDb.Dto
{
    public class CustomerDto
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
