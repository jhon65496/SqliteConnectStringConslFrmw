using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
            // GetAll();
            // GetAll1();
                GetAll3();
            // TestConnection();
        }   

        public void GetAll()
        {
            try
            {
                // 
                // string cs = @"C:\Projects\dbAppIndexes.db";
                // DbContextIndexes dbContextIndexes = new DbContextIndexes(cs);

                // 
                string path = @"c:\TestFile\DBTest\SQLite\01\dbAppIndexes2.db";
                string connectionString = $"Data Source={path}";
                DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionString);

                // 
                // string path = @"C:\Projects\dbAppIndexes3.db";
                // string connectionString = $"AttachDBFileName={path}";
                // DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionString);

                // 
                // string connectionStringsName = "DefaultConnection";
                // DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionStringsName);

                // 
                // DbContextIndexes dbContextIndexes = new DbContextIndexes();

                // 
                // string connectionStringsName = "DefaultConnection2";
                // DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionStringsName);

                IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

                var i = indexesRepository.Items.ToArray();
                var indexes = new ObservableCollection<Index>(i);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }            
        }



        public void GetAll1()
        {
            AppSettingService appSettingService = new AppSettingService();
            
            string path = @"C:\Projects\dbAppIndexes3.db";
            string connectionString = $"Data Source={path}";
            string connectionStringName = @"DefaultConnection";

            appSettingService.SaveConnectionString(connectionStringName, connectionString);
            
            DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionStringName);

            IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

            var i = indexesRepository.Items.ToArray();
            var indexes = new ObservableCollection<Index>(i);
        }

        public void GetAll2()
        {
            AppSettingService appSettingService = new AppSettingService();

            string path = @"C:\Projects\dbAppIndexes4.db";
            string connectionString = $"Data Source={path}";
            string connectionStringName = @"DefaultConnection";

            appSettingService.SaveConnectionString(connectionStringName, connectionString);

            DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionStringName);

            IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

            var i = indexesRepository.Items.ToArray();
            var indexes = new ObservableCollection<Index>(i);
        }

        #region Andrey-MSK_Answ_04 -- cyberforum.ru
        /*https://www.cyberforum.ru/post17132484.html
         */
        public void GetAll3()
        {
            try
            {
                // 
                string connectionStringBeginning = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string path = @"c:\TestFile\DBTest\SQLite\01\dbAppIndexes2.db";
                // string connectionString = $"Data Source={path}";
                string connectionStringResult = string.Format(connectionStringBeginning, path); // `Data Source=c:\TestFile\DBTest\SQLite\01\dbAppIndexes2.db`
                DbContextIndexes dbContextIndexes = new DbContextIndexes(connectionStringResult);

                

                IndexesRepository indexesRepository = new IndexesRepository(dbContextIndexes);

                var i = indexesRepository.Items.ToArray();
                var indexes = new ObservableCollection<Index>(i);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }

        public void TestConnection()
        {
            string connectionStringBeginning = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string path = @"c:\TestFile\DBTest\SQLite\01\dbAppIndexes2.db";
            // string connectionString = $"Data Source={path}";
            string connectionStringResult = string.Format(connectionStringBeginning, path); // `Data Source=c:\TestFile\DBTest\SQLite\01\dbAppIndexes2.db`    

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionStringResult))
                {
                    connection.Open();
                    
                    var connectionState = connection.State;

                    Console.WriteLine("Соединение установлено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
