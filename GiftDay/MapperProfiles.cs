using AutoMapper;
using GiftDay.Domain;
using GiftDay.Models;

namespace GiftDay {
    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<GiftEvent, GiftEventDto>();
            CreateMap<GiftEvent, UpcomingEventDto>();
            CreateMap<Person, PersonDto>();
        }
    }
}
