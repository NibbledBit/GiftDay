using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Domain {
    public class GiftEventAddedDomainEvent : INotification {
        public GiftEventAddedDomainEvent(GiftEvent eventAdded) {
            EventAdded = eventAdded;
        }

        public GiftEvent EventAdded { get; set; }

    }
}
