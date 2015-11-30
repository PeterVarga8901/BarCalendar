using System.Configuration;

namespace ClubArcada.BarCalendar.BusinessObjects
{
    public class Settings
    {
        public static string ConnectionString
        {
            get
            {
                //var cstring = ConfigurationManager.AppSettings["BARDB_" + ConfigurationManager.AppSettings["Enviroment"]];
                var cstring = "Data Source=82.119.117.77;Initial Catalog=ClubArcada.Bar_Live;User ID=BarUser;Password=Bar1969";
                return cstring;
            }
        }

        public static string ConnectionStringPS
        {
            get
            {
                var cstring = ConfigurationManager.AppSettings["DBPS_" + ConfigurationManager.AppSettings["Enviroment"]];
                return cstring;
            }
        }
    }
}