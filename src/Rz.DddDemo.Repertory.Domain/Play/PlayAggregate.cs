using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Base.Domain.DomainEvent;

namespace Rz.DddDemo.Repertory.Domain.Play
{
    public class PlayAggregate:DomainEntityBase<PlayId>
    {
        public PlayName PlayName { get; }

        public PlayAggregate(PlayId id, PlayName playName) : base(id)
        {
            PlayName = playName;
        }

        public PlayAggregate(PlayName playName):this(new PlayId(),playName)
        {
            
        }
    }
}
