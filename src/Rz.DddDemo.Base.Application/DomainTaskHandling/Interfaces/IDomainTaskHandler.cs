using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rz.DddDemo.Base.Application.DomainTaskHandling.Interfaces
{
    public interface IDomainTaskHandler
    {
        Task Handle(IDomainTask domainTask);
    }
}
