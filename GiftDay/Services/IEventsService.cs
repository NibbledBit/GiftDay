using GiftDay.Common;
using GiftDay.Domain;
using GiftDay.Models;

namespace GiftDay.Services
{
    public interface IEventsService : IService
    {
        public Task<GiftEventDto> CreateEvent(string eventTitle, EventType type, DateTime eventDate);
        public Task<IEnumerable<UpcomingEventDto>> GetEvents();

    }
}
