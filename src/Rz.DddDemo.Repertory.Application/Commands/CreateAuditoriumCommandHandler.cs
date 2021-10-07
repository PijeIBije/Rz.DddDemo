using System;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Repertory.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Repertory.Application.Interfaces;
using Rz.DddDemo.Repertory.Domain.Auditorium;

namespace Rz.DddDemo.Repertory.Application.Commands
{
    public class CreateAuditoriumCommandHandler:CommandHandlerBase<CreateAuditoriumCommand,AuditioriumId>
    {
        private readonly IAuditioriumRepository auditioriumRepository;

        public CreateAuditoriumCommandHandler(
            IAuditioriumRepository auditioriumRepository,
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.auditioriumRepository = auditioriumRepository;
        }

        protected override async Task<AuditioriumId> HandleBody(CreateAuditoriumCommand command)
        {
            var auditorium = new AuditoriumAggregate(command.Seats,command.Name);

            await auditioriumRepository.Save(auditorium);

            RegisterIntegrationEvent(new AuditoriumUpdatedIntegraionEvent(auditorium));

            return auditorium.Id;
        }
    }
}
