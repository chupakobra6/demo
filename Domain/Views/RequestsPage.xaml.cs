using demo.Core.Data;
using demo.Core.ViewModels;
using demo.Domain.Models;
using System.Windows.Controls;

namespace demo.Domain.Views
{
    /// <summary>
    /// Логика взаимодействия для RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        private readonly UnitOfWork _uow;
        public RequestsPage()
        {
            InitializeComponent();
            _uow = new UnitOfWork(new Entities());
            DataContext = new CrudViewModel<Request>(_uow);
        }
    }
}
