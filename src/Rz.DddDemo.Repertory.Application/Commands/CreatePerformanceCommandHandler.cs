using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.TransactionHandling;
using Rz.DddDemo.Repertory.Application.Interfaces;
using Rz.DddDemo.Repertory.Domain.Performance;

namespace Rz.DddDemo.Repertory.Application.Commands
{
    public class CreatePerformanceCommandHandler : CommandHandlerBase<CreatePerformanceCommand, PerformanceId>
    {
        private readonly IAuditioriumRepository auditioriumRepository;
        private readonly IPerformanceRepository performanceRepository;

        public CreatePerformanceCommandHandler(
            IAuditioriumRepository auditioriumRepository,
            IPerformanceRepository performanceRepository,
            DomainEventsHandler domainEventsHandler, IntegrationEventsPublisher integrationEventsPublisher,
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.auditioriumRepository = auditioriumRepository;
            this.performanceRepository = performanceRepository;
        }

        protected override async Task<PerformanceId> HandleBody(CreatePerformanceCommand command)
        {
            var performance = new PerformanceAggregate(command.AuditioriumId, command.PlayId, command.PerformanceDate);

            var auditiorium = await auditioriumRepository.GetById(command.AuditioriumId);

            foreach (var seatPricingCreationData in command.SeatPricings)
            {
                if(!auditiorium.RowsExist(seatPricingCreationData.Rows)) throw new Exception();
                performance.SetPricing(seatPricingCreationData.Rows,seatPricingCreationData.PricingName,seatPricingCreationData.Price);
            }

            await performanceRepository.Save(performance);

           //RegisterIntegrationEvent(new AuditoriumUpdatedIntegraionEvent(auditorium));

            return performance.Id;
        }
    }
}
