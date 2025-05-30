using demo.Core.Data;
using demo.Core.ViewModels;
using demo.Domain.Models;
using System.Windows.Controls;

namespace demo.Domain.Views
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private readonly UnitOfWork _uow;
        public UsersPage()
        {
            InitializeComponent();
            _uow = new UnitOfWork(new Entities());
            DataContext = new CrudViewModel<User>(_uow);
        }
    }
}
