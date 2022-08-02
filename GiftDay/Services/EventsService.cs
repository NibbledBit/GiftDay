using AutoMapper;
using GiftDay.Domain;
using GiftDay.Models;
using GiftDay.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GiftDay.Services {
    public class EventsService : IEventsService {
        private readonly GiftDayContext context;
        private readonly IMapper mapper;

        public EventsService(GiftDayContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GiftEventDto> CreateEvent(string eventTitle, EventType type, DateTime eventDate) {
            var events = context.Set<GiftEvent>();

            var newEvent = new GiftEvent(eventTitle, type, eventDate);

            events.Add(newEvent);

            await context.SaveChangesAsync();

            return mapper.Map<GiftEventDto>(newEvent);
        }

        public async Task<GiftEventDto> CreateEvent(int personId, EventType type, DateTime eventDate) {
            var events = context.Set<GiftEvent>();

            var people = context.Set<Person>();
            var person = people
                .Include(x => x.EventsToCelebrate)
                .FirstOrDefault(x => x.Id == personId);

            var title = $"{person.FirstName}'s {type}";

            var newEvent = person.AddEvent(title, type, eventDate);

            await context.SaveChangesAsync();

            return mapper.Map<GiftEventDto>(newEvent);
        }

        public async Task<IEnumerable<UpcomingEventDto>> GetEvents() {
            var events = context.Set<GiftEvent>()
                                .Include(x => x.Person);

            return mapper.Map<IEnumerable<UpcomingEventDto>>(await events.ToListAsync());
        }

        public async Task MarkGiftIsBought(int id, bool giftBought) {
            var events = context.Set<GiftEvent>()
                .Include(x => x.YearlyGiftsBought);

            var giftEvent = await events.FirstOrDefaultAsync(x => x.Id == id);

            if (giftEvent == null) throw new Exception("Event does not exist.");

            giftEvent.SetGiftBought(giftBought, DateTime.Today.Year);
        }
    }
}
