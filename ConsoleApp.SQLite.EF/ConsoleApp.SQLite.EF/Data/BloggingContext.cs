using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.SQLite.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.SQLite.EF.Data
{
    internal class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; set; }

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, "blogging.db");
        }

        // the following configures the EF to create a  sqlite database file in the special "local" folder for your application platform
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source = {DbPath}");
    }
}
