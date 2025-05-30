using demo.Core.Data;
using demo.Core.Services;
using demo.Domain.Models;
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

namespace demo.Domain.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            using (var u = new UnitOfWork(new Entities()))
            {
                var user = AuthService.Logon(LoginBox.Text, PassBox.Password, u);
                if (user == null) { MessageBox.Show("Неверные данные"); return; }

                NavigationService.GetNavigationService(this).Navigate(new RequestsPage());
            }
        }
    }
}
