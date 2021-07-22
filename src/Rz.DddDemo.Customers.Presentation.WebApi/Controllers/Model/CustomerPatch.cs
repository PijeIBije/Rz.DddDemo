using System;
using System.Collections.Generic;

namespace Rz.DddDemo.Customers.Presentation.WebApi.Controllers.Model
{
    public class CustomerPatch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressResource> AddressesToAddOrUpdate { get; set; } = new List<AddressResource>();
        public List<string> AddressesToRemove { get; set; } =new List<string>();
    }
}
