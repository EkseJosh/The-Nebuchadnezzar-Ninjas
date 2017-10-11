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
    /// Interaction logic for GameOverScreen.xaml
    /// </summary>
    public partial class GameOverScreen : Window
    {
     
       
        public GameOverScreen(int score,List<string> sc)
        {
            InitializeComponent();
          
            txtScoreShow.Text = $" {score}";
           
            int i = 0;

            while(i<sc.Count)
            {
                txtScoreList.Text = $"{txtScoreList.Text} \n {i}.  {sc[i]}    {sc[i + 1]}";
                i += 2;


            }
           
            
        }

       

        private void btnReturn_Click_1(object sender, RoutedEventArgs e)
        {
            new GameStartScreen().Visibility = Visibility.Visible;
            Visibility = Visibility.Hidden;
        }
    }
}
