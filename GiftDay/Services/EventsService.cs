using GiftDay.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Services
{
    public class EventsService : IEventsService
    {
        public IEnumerable<GiftEvent> GetEvents()
        {
            return new List<GiftEvent>() { new GiftEvent(DateTime.Today.AddDays(5), "My Event!") };
        }
    }
}
