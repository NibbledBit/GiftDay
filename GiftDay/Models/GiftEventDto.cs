using GiftDay.Domain;

namespace GiftDay.Models
{
    public class GiftEventDto
    {
        public virtual string EventName { get; }
        public virtual DateTime EventDate { get; }
        public virtual EventType EventType { get; }
    }
    public class UpcomingEventDto
    {


    }
}
