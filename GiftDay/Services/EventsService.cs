using AutoMapper;
using GiftDay.Domain;
using GiftDay.Models;
using GiftDay.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Services
{
    public class EventsService : IEventsService
    {
        private readonly GiftDayContext context;
        private readonly IMapper mapper;

        public EventsService(GiftDayContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GiftEventDto> CreateEvent(string eventTitle, EventType type, DateTime eventDate)
        {
            var events = context.Set<GiftEvent>();

            var newEvent = new GiftEvent(eventTitle, type, eventDate);

            events.Add(newEvent);

            await context.SaveChangesAsync();

            return mapper.Map<GiftEventDto>(newEvent);

        }

        public Task<GiftEventDto> CreateEvent(int personId, EventType type, DateTime eventDate)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<UpcomingEventDto>> GetEvents()
        {
            return Task.FromResult(new List<UpcomingEventDto>() { new UpcomingEventDto() }.AsEnumerable());
        }
    }
}
