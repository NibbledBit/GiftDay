using GiftDay.Common;
using GiftDay.Domain;

namespace GiftDay.Services
{
    public interface IEventsService : IService
    {
        public IEnumerable<GiftEvent> GetEvents();
    }
}
