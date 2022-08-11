using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace perfmon_explorer
{
    public partial class LoadingWindow
    {
        private readonly Task _promise;

        public LoadingWindow()
        {
            _promise = Task.CompletedTask;
            InitializeComponent();
        }

        private LoadingWindow(Task promise)
        {
            _promise = promise;
            InitializeComponent();
        }

        public static Task<TResult> AwaitResult<TResult>(Window owner, Task<TResult> promise)
        {
            var loadingWindow = new LoadingWindow(promise) { Owner = owner };
            loadingWindow.ShowDialog();
            return promise;
        }

        private async void LoadingWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await _promise;
            Close();
        }

        private void LoadingWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (!_promise.IsCompleted)
                e.Cancel = true;
        }
    }
}