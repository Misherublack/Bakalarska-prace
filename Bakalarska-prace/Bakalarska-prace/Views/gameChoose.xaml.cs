using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using WpfChatClient;

namespace Bakalarska_prace.Views
{
    /// <summary>
    /// Interakční logika pro gameChoose.xaml
    /// </summary>
    public partial class GameChoice : UserControl
    {
        public GameChoice()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new GameAgainstPc();
            }
        }
    }
}


