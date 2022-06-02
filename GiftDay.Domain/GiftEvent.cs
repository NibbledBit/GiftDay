using BitOfA.Helper.Persistence;

namespace GiftDay.Domain;

public class GiftEvent : IIntKeyedRecord
{
    public GiftEvent(DateTime eventDate, string eventTitle)
    {
        EventDate = eventDate;
        EventTitle = eventTitle;
    }

    public int Id { get; protected set; }

    public DateTime EventDate { get; set; }
    public string EventTitle { get; set; }

    public Person Person { get; set; }
    public int PersonId { get; set; }

}
