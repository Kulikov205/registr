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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Registr()
        {
            InitializeComponent();
            connect.modelbd = new Models.dozo();
        }

        private void Registraciya(object sender, RoutedEventArgs e)
        {
            // Получаем данные из полей ввода
            string login = Login.Text;
            string password = Password.Password;
            string confirmPassword = ConfirmPassword.Password;

            bool hasError = false;

            // Проверка длины логина
            if (login.Length < 5)
            {
                Login.ToolTip = "Мало символов!";
                Login.BorderBrush = Brushes.Red;
                hasError = true;
            }
            else
            {
                Login.ToolTip = "Все хорошо!";
                Login.BorderBrush = Brushes.LimeGreen;
            }

            // Проверка длины пароля
            if (password.Length < 5)
            {
                Password.ToolTip = "Мало символов!";
                Password.BorderBrush = Brushes.Red;
                hasError = true;
            }
            else
            {
                Password.ToolTip = "Все хорошо!";
                Password.BorderBrush = Brushes.LimeGreen;
            }

            // Проверяем, совпадают ли пароль и подтверждение пароля
            if (password != confirmPassword)
            {
                ConfirmPassword.ToolTip = "Пароли не совпадают!";
                ConfirmPassword.BorderBrush = Brushes.Red;
                hasError = true;
            }
            else
            {
                ConfirmPassword.ToolTip = "Все хорошо!";
                ConfirmPassword.BorderBrush = Brushes.LimeGreen;
            }

            if (hasError)
            {
                // Если есть ошибки, не выполняем регистрацию
                return;
            }

            // Создаем нового пользователя
            var newUser = new Models.users
            {
                login = login,
                password = password,
                id_type = 3 // 3 соответствует роли "Client"
            };

            // Добавляем пользователя в таблицу users
            connect.modelbd.users.Add(newUser);

            try
            {
                // Сохраняем изменения в базе данных
                connect.modelbd.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!", "Успешная регистрация",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                // Очищаем поля ввода
                Login.Clear();
                Password.Clear();
                ConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка при регистрации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

