using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using WpfChatClient;

namespace Bakalarska_prace.Views
{
    /// <summary>
    /// Interakční logika pro GameAgainstPc.xaml
    /// </summary>
    public partial class GameAgainstPc : UserControl
    {
        public GameAgainstPc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null)
            {
                mainWindow.MainContent.Content = new GameStart();
            }

        }
    }
}
