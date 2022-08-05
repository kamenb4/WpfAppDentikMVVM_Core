using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfAppDentikMVVM_Core.Model;

namespace WpfAppDentikMVVM_Core.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<DataPrice> dataPrices { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WpfAppDentikDB;Trusted_Connection=true"); 
        }
    }
}
