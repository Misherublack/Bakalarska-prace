using System.Windows;
using System.Windows.Controls;
using WpfChatClient;

namespace Bakalarska_prace.Views
{

    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new GameChoiceView();
            }
      
        }
    }
}
