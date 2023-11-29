using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteConnectStringConslFrmw.Service
{
    public class AppSettingService
    {
        Configuration config; 
        public AppSettingService()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);     
        }



        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SQLite";

            config.Save(ConfigurationSaveMode.Modified);

        }

    }
}
