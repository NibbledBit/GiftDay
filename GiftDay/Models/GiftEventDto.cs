using GiftDay.Domain;

namespace GiftDay.Models
{
    public class GiftEventDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public EventType Type { get; set; }
        public DateTime Date { get; set; }

        //public Person Person { get; protected set; }
        //public int? PersonId { get; protected set; }
    }
    public class UpcomingEventDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public EventType Type { get; set; }
        public DateTime Date { get; set; }


        //public Person Person { get; protected set; }
        //public int? PersonId { get; protected set; }
    }
}
