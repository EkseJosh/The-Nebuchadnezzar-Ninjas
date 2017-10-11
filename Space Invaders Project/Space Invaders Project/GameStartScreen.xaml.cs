using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Space_Invaders_Project
{
    /// <summary>
    /// Interaction logic for GameStartScreen.xaml
    /// </summary>
    public partial class GameStartScreen : Window
    {
        public GameStartScreen()
        {
            InitializeComponent();
           
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Visibility = Visibility.Visible;
            Visibility = Visibility.Hidden;

        }
    }
}
