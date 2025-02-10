using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFnba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["WPFnba.Properties.Settings.WPFnbaConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            this.showTeams();
        }

        private void showTeams()
        {
            string query = "SELECT * FROM Team";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            using (adapter)
            {
                DataTable teamTable = new DataTable();
                adapter.Fill(teamTable);

                listTeams.ItemsSource = teamTable.DefaultView;
                listTeams.SelectedValuePath = "teamId";
                listTeams.DisplayMemberPath = "teamName";
            }
        }
    }
}
