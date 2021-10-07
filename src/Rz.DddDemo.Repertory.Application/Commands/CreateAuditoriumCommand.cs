using System.Collections.Generic;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Repertory.Domain.Auditorium;

namespace Rz.DddDemo.Repertory.Application.Commands
{
    public class CreateAuditoriumCommand:ICommand<AuditioriumId>
    {
        public AuditoriumName Name { get; }
        public IReadOnlyList<Row> Seats { get; }

        public CreateAuditoriumCommand(AuditoriumName name, IReadOnlyList<Row> seats)
        {
            Name = name;
            Seats = seats;
        }
    }
}
