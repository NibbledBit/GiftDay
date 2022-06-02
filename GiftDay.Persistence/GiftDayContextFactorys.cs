using BitOfA.Helper.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Persistence
{
    //public class GiftDayContextFactory : IContextFactory<GiftDayContext>
    //{
    //    private readonly DbContextOptions<GiftDayContext> options;

    //    public GiftDayContextFactory(DbContextOptions<GiftDayContext> options)
    //    {
    //        this.options = options;
    //    }

    //    public GiftDayContext CreateContext()
    //    {
    //        return new GiftDayContext(options);
    //    }

    //}
    //public class GiftDayDesignTimeContextFacory : IDesignTimeDbContextFactory<GiftDayContext> {

    //    public GiftDayContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<GiftDayContext>();
    //        optionsBuilder.UseSqlite("Date Source=GiftDayMigsDb.db");

    //        return new GiftDayContext(optionsBuilder.Options);

    //    }
    //}
}
