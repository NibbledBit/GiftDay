using BitOfA.Helper.Persistence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftDay.Domain;

public class Person : IIntKeyedRecord {
    protected Person() { }
    public Person(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; protected set; }

    [Required, MaxLength(200)]
    public string FirstName { get; protected set; }
    [MaxLength(200)]
    public string LastName { get; protected set; }

    [NotMapped]
    public string Name {
        get {
            if (string.IsNullOrEmpty(LastName))
                return FirstName;
            else
                return $"{FirstName} {LastName}";
        }
    }

    public ICollection<GiftEvent> EventsToCelebrate { get; protected set; }

    public GiftEvent AddEvent(string title, EventType type, DateTime eventDate) {

        var newEvent = new GiftEvent(title, type, eventDate);
        EventsToCelebrate.Add(newEvent);
        return newEvent;
    }
}
