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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            Window win1 = new MainWindow();
            win1.Show();
            this.Close();
        }

        private void regista_Click(object sender, RoutedEventArgs e)
        {
            bool number = false;

            if (txtlogin1.Text.Length > 0)
            {
                if (txtpassword1.Password.Length > 0)
                {
                    if (txtpassword1.Password.Length >= 6)
                    {
                        for (int i = 0; i < txtpassword1.Password.Length; i++)
                        {
                            if (txtpassword1.Password[i] >= '0' && txtpassword1.Password[i] <= '9')
                                number = true;
                        }
                        if (number == true)
                        {
                            if (txtpassword2.Password.Length >= 6)
                            {
                                if (txtpassword1.Password == txtpassword2.Password)
                                {
                                    string cp = "server=localhost;user=root;database=testdb;Sslmode=none;";
                                    MySqlConnection connectioin = new MySqlConnection(cp);
                                    connectioin.Open();
                                    MySqlCommand cmd = connectioin.CreateCommand();
                                    cmd.CommandType = CommandType.Text;
                                    string query = "insert into new(login,password,rol) VALUES('" + txtlogin1.Text +"','"+txtpassword1.Password+"',1)";
                                    MySqlCommand cmd1 = new MySqlCommand(query,connectioin);
                                    cmd1.ExecuteNonQuery();





                                    MessageBox.Show("Пользователь зарегестрирован");
                                    Window win1 = new MainWindow();
                                    win1.Show();
                                    this.Close();

                                }
                                else
                                    MessageBox.Show("Пароли не сходятся");
                            }
                            else
                                MessageBox.Show("Укажите второй пароль");
                        }
                        else
                            MessageBox.Show("В пароли должна быть хоть одна цифра");
                    }
                    else
                        MessageBox.Show("В пароле должно быть хоть минимум 6 символов");
                }
                else
                    MessageBox.Show("Укажите пароль");
            }
            else
                MessageBox.Show("Укажите логин");
        }
    }
}
