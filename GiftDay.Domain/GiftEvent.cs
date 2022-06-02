namespace GiftDay.Domain
{
    public class GiftEvent
    {
        public GiftEvent(DateTime eventDate, string eventTitle)
        {
            EventDate = eventDate;
            EventTitle = eventTitle;
        }

        public DateTime EventDate { get; set; }
        public string EventTitle { get; set; }


    }
}
