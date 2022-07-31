using MediatR;

namespace GiftDay.Domain;

public interface ISupportDomainEvents {
    List<INotification> DomainEvents { get; }
}
