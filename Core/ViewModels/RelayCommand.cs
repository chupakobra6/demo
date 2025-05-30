using System;
using System.Windows.Input;

namespace demo.Core.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _act; private readonly Func<object, bool> _can;
        public RelayCommand(Action<object> act, Func<object, bool> can = null)
            => (_act, _can) = (act, can);
        public bool CanExecute(object p) => _can?.Invoke(p) ?? true;
        public void Execute(object p) => _act(p);
        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
