using Rz.DddDemo.Base.Application.QueryHandling;
using Rz.DddDemo.Base.Application.QueryHandling.Intefaces;

namespace Rz.DddDemo.Reservations.Application.Queries
{
    public class OrderQuery:IQuery
    { 
        public OrderId OrderId { get; set; }

        public SortDirection? SortDirection { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
    }
}
