using GiftDay.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Services {
    public class GiftEventAddedHandler : INotificationHandler<GiftEventAddedDomainEvent> {
        public Task Handle(GiftEventAddedDomainEvent notification, CancellationToken cancellationToken) {
            Console.WriteLine(notification.EventAdded.Date);
            return Task.CompletedTask;
        }

    }
}
