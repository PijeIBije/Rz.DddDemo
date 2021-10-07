using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Repertory.Domain.Auditorium;

namespace Rz.DddDemo.Repertory.Application.IntegrationEvents.Outbound
{
    public class AuditoriumUpdatedIntegraionEvent:IIntegrationEvent
    {
        public AuditoriumAggregate Auditorium { get; }

        public AuditoriumUpdatedIntegraionEvent(AuditoriumAggregate auditorium)
        {
            Auditorium = auditorium;
        }
    }
}
