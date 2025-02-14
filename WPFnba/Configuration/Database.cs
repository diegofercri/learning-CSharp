using System.Configuration;
using System.Data.Linq;

/// <summary>
/// Static class that handles the database connection using LINQ to SQL.
/// </summary>
public static class Database
{
    private static DataContext _dataContext; // Data context used to interact with the database.

    /// <summary>
    /// Gets an instance of the data context. If it doesn't exist, a new instance is created.
    /// </summary>
    /// <returns>An instance of DataContext.</returns>
    public static DataContext GetContext()
    {
        // Checks if the data context has already been initialized.
        if (_dataContext == null)
        {
            // Retrieves the connection string from the application configuration file.
            string connectionString = ConfigurationManager.ConnectionStrings["WPFnba.Properties.Settings.nbadbConnectionString"].ConnectionString;

            // Initializes the data context with the connection string.
            _dataContext = new DataContext(connectionString);
        }

        // Returns the data context.
        return _dataContext;
    }
}