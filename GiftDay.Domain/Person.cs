using BitOfA.Helper.Persistence;

namespace GiftDay.Domain;

public class Person : IIntKeyedRecord
{
    public Person(string firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; protected set; }

    public string FirstName { get; protected set; }
    public string? LastName { get;protected set; }

    public ICollection<GiftEvent>? EventsToCelebrate { get; protected set; } 



}
