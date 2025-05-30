using demo.Core.Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace demo.Core.ViewModels
{
    public class CrudViewModel<T> : BaseViewModel where T : class, new()
    {
        private readonly UnitOfWork _uow;
        private readonly Repository<T> _repo;

        public ObservableCollection<T> Items { get; }
        public ICommand AddCmd { get; }
        public ICommand DeleteCmd { get; }
        public ICommand SaveCmd { get; }

        private T _current;
        public T Current { get => _current; set => Set(ref _current, value); }

        public CrudViewModel(UnitOfWork uow)
        {
            _uow = uow;
            _repo = uow.Repo<T>();

            Items = new ObservableCollection<T>(_repo.All());
            Current = Items.FirstOrDefault();

            AddCmd = new RelayCommand(_ => Add());
            DeleteCmd = new RelayCommand(_ => Delete(), _ => Current != null);
            SaveCmd = new RelayCommand(_ => Save());
        }

        private void Add()
        {
            var e = new T();
            Items.Add(e);
            Current = e;
            _repo.Add(e);
        }

        private void Delete()
        {
            _repo.Remove(Current);
            Items.Remove(Current);
            Current = Items.FirstOrDefault();
        }

        private bool HasNullRequired(T e)
        {
            return typeof(T).GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(RequiredAttribute)))
                .Any(p =>
                {
                    var v = p.GetValue(e);
                    return v == null || (v is string s && string.IsNullOrWhiteSpace(s));
                });
        }

        private void Save()
        {
            if (Items.Any(HasNullRequired))
            {
                MessageBox.Show("Заполните все обязательные поля!", "Валидация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _uow.Commit();
        }
    }
}
