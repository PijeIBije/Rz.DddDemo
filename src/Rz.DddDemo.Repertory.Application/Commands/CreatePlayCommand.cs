using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.CommandHandling.Interfaces;
using Rz.DddDemo.Repertory.Domain.Play;

namespace Rz.DddDemo.Repertory.Application.Commands
{
    public class CreatePlayCommand:ICommand<PlayId>
    {
        public CreatePlayCommand(PlayName playName)
        {
            PlayName = playName;
        }

        public PlayName PlayName { get; }
    }
}
