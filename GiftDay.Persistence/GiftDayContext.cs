using BitOfA.Helper.DDD;
using GiftDay.Domain;
using Microsoft.EntityFrameworkCore;

namespace GiftDay.Persistence
{
    public class GiftDayContext : DbContext
    {
        private readonly INotifyDispatcher dispatcher;

        public GiftDayContext(DbContextOptions<GiftDayContext> options, INotifyDispatcher notifyDispatcher) : base(options)
        {
            this.dispatcher = notifyDispatcher;
        }
        public GiftDayContext(DbContextOptions<GiftDayContext> options) : base(options)
        {
        }

        public DbSet<GiftEvent> EventsToCelebrate { get; set; }

        public DbSet<Person> People { get; set; }


        public override int SaveChanges()
        {
            NotifyDomain();

            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            NotifyDomain();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void NotifyDomain()
        {
            var iDomains = ChangeTracker.Entries<IDomainModel>()
                .ToList().Select(x => x.Entity);

            var domainEventEntities = iDomains
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                var events = entity.DomainEvents.ToArray();
                entity.DomainEvents.Clear();
                foreach (var domainEvent in events)
                {
                    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation#the-domain-event-dispatcher-mapping-from-events-to-event-handlers
                    dispatcher.Dispatch(domainEvent);
                }
            }
        }


    }
}
