using demo.Core.Services;
using System.Collections.Generic;
using System.Windows;

namespace demo.Domain.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NavService _nav;
        private readonly IEnumerable<string> _navKeys;
        public MainWindow()
        {
            InitializeComponent();
            _nav = new NavService(Host);
            _nav.Register<LoginPage>("Вход");
            _nav.Register<UsersPage>("Пользователи");
            _nav.Register<RequestsPage>("Заявки");
            _nav.Register<CommentsPage>("Комментарии");
            _navKeys = _nav.Keys;
            Menu.ItemsSource = _navKeys;
            Menu.SelectionChanged += (_, __) => _nav.Go(Menu.SelectedItem.ToString());
            Menu.SelectedIndex = 0;
        }
    }
}
