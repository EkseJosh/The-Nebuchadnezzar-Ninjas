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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Space_Invaders_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        DispatcherTimer alienAttacktimer;
        SpaceShip ship;
        public double SpaceshipXPos = 563; // left of spaceship relative to canvas.
        public double SpaceShipYPos = 459; // top of spaceship image relative to canvas...Must Not be changed.



        public MainWindow()
        {
            InitializeComponent();

           

            // initialization of timers

            // update screen Timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;

            // alienAttackTimer
            alienAttacktimer = new DispatcherTimer();
            alienAttacktimer.Interval = TimeSpan.FromMinutes(1.5);

            // initialization of spaceship object 
            ship = new SpaceShip();
            ship.velocityX = 2;
            




        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {

                case Key.Left: spaceShipMove("Left");break;
                case Key.Right: spaceShipMove("Right");break;
            }
        }


        // method for movement of spaceship
        private void spaceShipMove(string direction)
        {

            switch(direction)
            {
                case "Left":

                    SpaceshipXPos += -ship.velocityX;
                    Canvas.SetLeft(SpaceShip, SpaceshipXPos); break;


                case "Right": SpaceshipXPos += ship.velocityX;break;


            }
            
           

        }
    }
}
