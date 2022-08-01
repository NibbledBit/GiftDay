using AutoMapper;
using GiftDay.Domain;
using GiftDay.Models;
using GiftDay.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GiftDay.Services;

public class PersonService : IPersonService
{
    private readonly GiftDayContext context;
    private readonly IMapper mapper;

    public PersonService(GiftDayContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    } 

    public async Task<PersonDto> CreatePerson()
    {
        var persons = context.Set<Person>();
        var newPerson = new Person("Nibbled", "Bit");
        persons.Add(newPerson);
        await context.SaveChangesAsync();

        return mapper.Map<PersonDto>(newPerson);
    }
}
