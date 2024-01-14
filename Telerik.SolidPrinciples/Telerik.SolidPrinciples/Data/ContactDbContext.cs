using Microsoft.EntityFrameworkCore;
using Telerik.SolidPrinciples.Models;

namespace Telerik.SolidPrinciples.Data
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public string DbPath { get; set; }

        public ContactDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, "contacts_db.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source = {DbPath}");
    }
}
