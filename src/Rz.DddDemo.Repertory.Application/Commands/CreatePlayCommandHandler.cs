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
using Rz.DddDemo.Repertory.Domain.Play;

namespace Rz.DddDemo.Repertory.Application.Commands
{
    public class CreatePlayCommandHandler:CommandHandlerBase<CreatePlayCommand,PlayId>
    {
        private readonly IPlayRepository playRepository;

        public CreatePlayCommandHandler(
            IPlayRepository playRepository,
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher, 
            Transaction transaction) : base(domainEventsHandler, integrationEventsPublisher, transaction)
        {
            this.playRepository = playRepository;
        }

        protected override async Task<PlayId> HandleBody(CreatePlayCommand command)
        {
            var play = new PlayAggregate(command.PlayName);

            await playRepository.Save(play);

            //RegisterIntegrationEvent(new AuditoriumUpdatedIntegraionEvent(auditorium));

            return play.Id;
        }
    }
}
