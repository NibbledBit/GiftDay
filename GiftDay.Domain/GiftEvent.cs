using BitOfA.Helper.Persistence;

namespace GiftDay.Domain;

public class GiftEvent : IIntKeyedRecord
{

    public GiftEvent(string eventTitle, EventType type, DateTime eventDate)
    {
        Date = eventDate;
        Title = eventTitle;
        Type = type;
    }

    public int Id { get; protected set; }

    public string Title { get; protected set; }
    public EventType Type { get; protected set; }
    public DateTime Date { get; protected set; }


    public Person Person { get; protected set; }
    public int PersonId { get; protected set; }

    public void AddPerson(Person person)
    {
        Person = person;
    }

}
