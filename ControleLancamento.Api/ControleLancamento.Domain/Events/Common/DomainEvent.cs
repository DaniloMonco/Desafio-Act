using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Domain.Events.Common
{
    public abstract record DomainEvent(Guid EventId, DateTime TimeStamp) : INotification
    {
        protected DomainEvent() : this(Guid.NewGuid(), DateTime.Now)
        {
        }
        public Guid EventId { get; private set; } = EventId;
        public DateTime TimeStamp { get; private set; } = TimeStamp;
    }
}
