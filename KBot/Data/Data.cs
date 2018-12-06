using System.Linq;
using System.Threading.Tasks;
using KBot.Resources;
using KBot.Resources.Database;

namespace KBot.Data
{
    public static class Data
    {
        public static Person GetUser(ulong UserId)
        {
            using (var DbContext = new SqliteDbContext())
            {
                var qry = DbContext.People.Where(x => x.Id == UserId);
                if (qry.Count() < 1)
                {
                    return null;
                } else
                {
                    return qry.FirstOrDefault();
                }
            }
        }

        public static async Task SaveUser(Person person)
        {
            if (person == null)
            {
                System.Console.WriteLine("Person passed was null.");
            }
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.People.Where(x => x.Id == person.Id).Count() > 0)
                {
                    Person Current = DbContext.People.Where(x => x.Id == person.Id).FirstOrDefault();
                    DbContext.Entry(Current).CurrentValues.SetValues(person);
                    DbContext.People.Update(Current);
                } else
                {
                    DbContext.People.Add(person);
                }
                await DbContext.SaveChangesAsync();
                System.Console.WriteLine("User updated.");
            }
        }
    }
}
