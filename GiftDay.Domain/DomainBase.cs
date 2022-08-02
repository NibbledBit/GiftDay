using BitOfA.Helper.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Domain {
    public abstract class DomainBase : IIntKeyedRecord, ISupportDomainEvents {

        protected DomainBase() {
            domainEvents = new List<INotification>();
        }


        public int Id { get; protected set; }

        private List<INotification> domainEvents;
        public List<INotification> DomainEvents => domainEvents;

        protected void AddDomainEvent(INotification eventItem) {
            domainEvents.Add(eventItem);
        }

        protected void RemoveDomainEvent(INotification eventItem) {
            domainEvents?.Remove(eventItem);
        }
    }
}
