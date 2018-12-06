using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using KBot.Resources.Database;
using Discord;
using Discord.WebSocket;
using System.Linq;

namespace KBot.Resources
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            string DbLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.1\KBot.dll", @"Data\");
            Options.UseSqlite($"Data Source={DbLocation}Database.sqlite");
            
        }
    }
}
