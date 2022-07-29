﻿using AutoMapper;
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
        private readonly DbContext context;
        private readonly IMapper mapper;

        public EventsService(DbContext context, IMapper mapper)
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

        public async Task<GiftEventDto> CreateEvent(int personId, EventType type, DateTime eventDate)
        {
            var events = context.Set<GiftEvent>();

            var people = context.Set<Person>();
            var person = people.FirstOrDefault(x => x.Id == personId);

            var title = $"{person.FirstName}'s {type}";

            var newEvent = new GiftEvent(title, type, eventDate);
            newEvent.AddPerson(person);

            events.Add(newEvent);

            await context.SaveChangesAsync();

            return mapper.Map<GiftEventDto>(newEvent);
        }

        public async Task<IEnumerable<UpcomingEventDto>> GetEvents()
        {
            var events = context.Set<GiftEvent>();

            return mapper.Map<IEnumerable<UpcomingEventDto>>(await events.ToListAsync());
        }
    }
}
