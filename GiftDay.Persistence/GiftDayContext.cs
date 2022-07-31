using GiftDay.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftDay.Persistence {
    public class GiftDayContext : DbContext {
        private readonly IMediator mediator;

        public GiftDayContext(DbContextOptions<GiftDayContext> options, IMediator mediator) : base(options) {
            this.mediator = mediator;
        }
        public GiftDayContext(DbContextOptions<GiftDayContext> options) : base(options) {
        }

        public DbSet<GiftEvent> EventsToCelebrate { get; set; }

        public DbSet<Person> People { get; set; }


        public override int SaveChanges() {
            NotifyDomain();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            NotifyDomain();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void NotifyDomain() {
            var iDomains = ChangeTracker.Entries<ISupportDomainEvents>()
                .ToList().Select(x => x.Entity);

            var domainEventEntities = iDomains
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities) {
                var events = entity.DomainEvents.ToArray();
                entity.DomainEvents.Clear();
                foreach (var domainEvent in events) {
                    mediator?.Publish(domainEvent);
                }
            }
        }


    }
}
