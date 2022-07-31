// See https://aka.ms/new-console-template for more information
using GiftDay.Persistence;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<GiftDayContext>();
optionsBuilder.UseSqlite("Data Source=GiftDayMigsDb.db");

var ctx = new GiftDayContext(optionsBuilder.Options);