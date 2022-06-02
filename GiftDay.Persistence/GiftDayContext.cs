using GiftDay.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Persistence
{
    public class GiftDayContext : DbContext
    {
        private readonly DbContextOptions<GiftDayContext> options;

        public GiftDayContext(DbContextOptions<GiftDayContext> options)
        {
            this.options = options;
        }

        public DbSet<GiftEvent>? EventsToCelebrate { get; set; }

        public DbSet<Person>? People { get; set; }


    }
}
