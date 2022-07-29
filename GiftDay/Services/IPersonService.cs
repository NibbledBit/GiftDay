using GiftDay.Common;
using GiftDay.Models;

namespace GiftDay.Services;

public interface IPersonService : IService
{
    Task<PersonDto> CreatePerson();
}
