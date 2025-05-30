using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Windows;

namespace demo.Core.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _ctx;
        public UnitOfWork(DbContext ctx) => _ctx = ctx;

        public Repository<T> Repo<T>() where T : class => new Repository<T>(_ctx);

        public void Commit()
        {
            try { _ctx.SaveChanges(); }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных.\n" + ex.Message, "Сохранение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Dispose() => _ctx.Dispose();
    }
}