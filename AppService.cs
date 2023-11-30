using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using SqliteConnectStringConslFrmw.Models;
using SqliteConnectStringConslFrmw.Service;

namespace SqliteConnectStringConslFrmw
{
    class AppService
    {
        public AppService()
        {
            
            TestMain();
        }

        public void TestMain()
        {    
            // Отв--steve-py--stackoverflow.com
            GetAll3();
            GetAll4();
        }

        #region steve-py--stackoverflow.com --- --- --- --- --- --- --- --- --- --- --- ---
        public void GetAll3()
        {
            string path = @"c:\TestFile\DBTest\SQLite\01\dbAppIndexes3.db";
            string connectionString = $"Data Source={path}";

            DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionString);

            IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

            var i = indexesRepository.Items.ToArray();
            var indexes = new ObservableCollection<Index>(i);
        }

        public void GetAll4()
        {
            string path = @"c:\TestFile\DBTest\SQLite\01\dbAppIndexes4.db";
            string connectionString = $"Data Source={path}";

            DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionString);

            IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

            var i = indexesRepository.Items.ToArray();
            var indexes = new ObservableCollection<Index>(i);
        }
        #endregion

        #region Авеш Вишвакарма -- codeproject.com

        public void GetAll5()
        {
            string path = @"c:\TestFile\DBTest\SQLite\01\dbAppIndexes3.db";
            // string connectionString = $"Data Source={path}";
                        
            var connectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = path,
                ForeignKeys = true
            }.ConnectionString;

            var sqliteConnection = new SQLiteConnection()
            {
                ConnectionString = connectionString
            };

            DbContextIndexes dbContextIndexes = new DbContextIndexes(sqliteConnection);

            IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

            var i = indexesRepository.Items.ToArray();
            var indexes = new ObservableCollection<Index>(i);
        }   
        #endregion
    }
}
