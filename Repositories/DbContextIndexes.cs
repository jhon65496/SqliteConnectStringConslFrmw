using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteConnectStringConslFrmw.Models;

namespace SqliteConnectStringConslFrmw
{
    public class DbContextIndexes : DbContext
    {
        public DbContextIndexes() : base("DefaultConnection")
        {

        }
        
        //public DbContextIndexes(string connectionStringsName) : base(connectionStringsName)
        //{

        //}

        public DbContextIndexes(string connectionString) : this() // Use "DefaultConnection" app connection string and
        {
            Database.Connection.ConnectionString = connectionString; // Overwrite to use the desired connection string.
        }

        public DbSet<Index> Indexes { get; set; }        
    }
}
