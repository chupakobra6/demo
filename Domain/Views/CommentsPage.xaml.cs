using demo.Core.Data;
using demo.Core.ViewModels;
using demo.Domain.Models;
using System.Windows.Controls;

namespace demo.Domain.Views
{
    /// <summary>
    /// Логика взаимодействия для CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        private readonly UnitOfWork _uow;
        public CommentsPage()
        {
            InitializeComponent();
            _uow = new UnitOfWork(new Entities());
            DataContext = new CrudViewModel<Comment>(_uow);
        }
    }
}
