using GiftDay.Common;
using GiftDay.Domain;
using GiftDay.Models;

namespace GiftDay.Services
{
    public interface IEventsService : IService
    {
        public GiftEventDto CreateEvent(string eventTitle, EventType type, DateTime eventDate);
        public GiftEventDto CreateEvent(int personId, EventType type, DateTime eventDate);
        public IEnumerable<UpcomingEventDto> GetEvents();

    }
}
