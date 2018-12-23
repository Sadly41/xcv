using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp5.Properties
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            string cp = "server=localhost;user=root;database=testdb;Sslmode=none";
            MySqlConnection connect = new MySqlConnection(cp);
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand("select * from new_table1", connect);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dtgrid.DataContext = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
