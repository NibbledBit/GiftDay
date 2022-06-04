using AutoMapper;
using GiftDay.Domain;
using GiftDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GiftEvent, GiftEventDto>();
            CreateMap<GiftEvent, UpcomingEventDto>();
            CreateMap<Person, PersonDto>();
        }
    }
}
