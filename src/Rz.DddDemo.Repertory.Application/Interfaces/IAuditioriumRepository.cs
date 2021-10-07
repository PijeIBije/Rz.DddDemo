using System.Threading.Tasks;
using Rz.DddDemo.Repertory.Domain.Auditorium;

namespace Rz.DddDemo.Repertory.Application.Interfaces
{
    public interface IAuditioriumRepository
    {
        Task Save(AuditoriumAggregate auditorium);

        Task<AuditoriumAggregate> GetById(AuditioriumId id);
    }
}
