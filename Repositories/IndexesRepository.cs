using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteConnectStringConslFrmw.Models;

namespace SqliteConnectStringConslFrmw
{
    class IndexesRepository 
    {

        DbContextIndexes _db;
        #region Конструктор --- --- --- ---
        public IndexesRepository(DbContextIndexes db)
        {
            _db = db;
        }
        #endregion

        public IQueryable<Index> Items => _db.Indexes;

    }
}
