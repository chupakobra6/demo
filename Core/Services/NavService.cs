using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace demo.Core.Services
{
    public class NavService
    {
        private readonly Frame _frame;
        private readonly Dictionary<string, Func<Page>> _pages = new Dictionary<string, Func<Page>>();
        public IEnumerable<string> Keys => _pages.Keys;
        public NavService(Frame frame) => _frame = frame;
        public void Register<T>(string key) where T : Page, new() => _pages[key] = () => new T();
        public void Go(string key) => _frame.Navigate(_pages[key]());

    }
}
