using Sport.Classes;
using System;
using System.Collections.Generic;
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

namespace Sport.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorizacia.xaml
    /// </summary>
    public partial class Autorizacia : Page
    {
        public Autorizacia()
        {
            InitializeComponent();
            connect.modelbd = new Models.dozo();
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new Registr());
        }

        private void Vxod(object sender, RoutedEventArgs e)
        {
            var userObj = connect.modelbd.users.FirstOrDefault(
                x => x.login == Login.Text && Password.Password == x.password);

            if (userObj == null)
            {
                MessageBox.Show("Пользователя с такими данными не существует!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (userObj.id_type == 1)
                {
                    manager.MainFrame.Navigate(new Admin());
                }
                else if (userObj.id_type == 2)
                {
                    manager.MainFrame.Navigate(new Manager());
                }
                else if (userObj.id_type == 3)
                {
                    manager.MainFrame.Navigate(new User());
                }
            }
        }

        
    }
}
