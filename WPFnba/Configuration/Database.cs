using System.Configuration;
using System.Data.Linq;

public static class Database
{
    private static DataContext _dataContext;

    public static DataContext GetContext()
    {
        if (_dataContext == null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WPFnba.Properties.Settings.nbadbConnectionString"].ConnectionString;
            _dataContext = new DataContext(connectionString);
        }
        return _dataContext;
    }
}