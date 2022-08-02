using GiftDay.Domain;

namespace GiftDay.Models {
    public class GiftEventDto {
        public int Id { get; set; }

        public string Title { get; set; }
        public EventType Type { get; set; }
        public DateTime Date { get; set; }
    }
    public class UpcomingEventDto {
        public int Id { get; set; }

        public string Title { get; set; }
        public EventType Type { get; set; }
        public DateTime Date { get; set; }

        public string PersonName { get; set; }

        public bool GiftBought { get; set; }

    }
}
