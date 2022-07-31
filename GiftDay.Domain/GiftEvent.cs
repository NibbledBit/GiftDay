using BitOfA.Helper.Persistence;
using MediatR;

namespace GiftDay.Domain;
public class GiftEvent : IIntKeyedRecord, ISupportDomainEvents {
    protected GiftEvent() {
        domainEvents = new List<INotification>();
    }

    public GiftEvent(string eventTitle, EventType type, DateTime eventDate) {
        domainEvents = new List<INotification>();

        Date = eventDate;
        Title = eventTitle;
        Type = type;

        AddDomainEvent(new GiftEventAddedDomainEvent(this));
    }

    public int Id { get; protected set; }

    public string Title { get; protected set; }
    public EventType Type { get; protected set; }
    public DateTime Date { get; protected set; }


    public Person Person { get; protected set; }
    public int? PersonId { get; protected set; }

    public void AddPerson(Person person) {
        Person = person;
    }


    private List<INotification> domainEvents;
    public List<INotification> DomainEvents => domainEvents;

    public void AddDomainEvent(INotification eventItem) {
        domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem) {
        domainEvents?.Remove(eventItem);
    }
}
