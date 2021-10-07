using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Repertory.Domain.Play;

namespace Rz.DddDemo.Repertory.Application.Interfaces
{
    public interface IPlayRepository
    {
        Task Save(PlayAggregate playAggregate);
    }
}
