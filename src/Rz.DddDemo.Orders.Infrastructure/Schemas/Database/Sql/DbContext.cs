using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Rz.DddDemo.Orders.Infrastructure.CustomerRepository.EntityFrameworkWithDapper;
using Rz.DddDemo.Orders.Infrastructure.OrderRepository.EntityFrameworkWithDapper;

namespace Rz.DddDemo.Orders.Infrastructure.SqlDb
{
    public class DbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<CustomerDto> Customers { get; set; }

        public DbSet<OrderDto> Orders { get; set; }

        
    }
}
