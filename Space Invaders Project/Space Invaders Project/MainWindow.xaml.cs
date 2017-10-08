using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        DispatcherTimer bulletTimer;
        SpaceShip ship;
        Boolean isShot;
        
        public double SpaceshipXPos = 563; // left of spaceship relative to canvas.
        public double SpaceShipYPos = 459; // top of spaceship image relative to canvas...Must Not be changed.
        public double BulletVelocity = 5;
        public double AlienVelocityX = 5;



        public MainWindow()
        {
            InitializeComponent();



            // initialization of timers

            // update screen Timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += Timer_Tick;

            // alienAttackTimer
            alienAttacktimer = new DispatcherTimer();
            alienAttacktimer.Interval = TimeSpan.FromMinutes(1.5);

            // initialization of spaceship object 
            ship = new SpaceShip();
            ship.velocityX = 1;



            // bullet timer





            // hide bullet





        }


        private void Timer_Tick(object sender, EventArgs e)
        {
           

        }
        
        public void AlienMovement(Image alien)
        {
            Canvas.SetRight(alien, AlienVelocityX);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.Left: spaceShipMove("Left"); break;
                case Key.Right: spaceShipMove("Right"); break;
                case Key.Space: shoot(); break;
            }
        }

        private void shoot()
        {
            isShot = true;
            bulletTimer = new DispatcherTimer();
            bulletTimer.Interval = TimeSpan.FromMilliseconds(5000);
            bulletTimer.IsEnabled = true;
            bulletTimer.Tick += BulletTimer_Tick;
                    

        }

        public bool bulletCollidesWithAlien(Image alien)
        {
            double bulletX = Canvas.GetLeft(bullet) + bullet.ActualWidth / 2.0;
            double bulletY = Canvas.GetTop(bullet) + bullet.ActualHeight;
            double leftalien = Canvas.GetLeft(alien);
            double alienX = leftalien + alien.ActualHeight;
            double ta = Canvas.GetTop(alien);
            bool hits = bulletX >= leftalien && bulletX < alienX && bulletY >= ta;
            bulletTimer.IsEnabled = false;
            isShot = false;
            return hits;
        }

        private void BulletTimer_Tick(object sender, EventArgs e)
        {
            double nextY = Canvas.GetTop(bullet) + 1;
            Canvas.SetTop(bullet, nextY);
            if ((Alien1.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien1))
            {
                Alien1.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien2.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien2))
            {
                Alien2.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien3.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien3))
            {
                Alien3.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien4.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien4))
            {
                Alien4.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien5.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien5))
            {
                Alien5.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien6.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien6))
            {
                Alien6.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien7.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien7))
            {
                Alien7.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien8.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien8))
            {
                Alien8.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien9.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien9))
            {
                Alien9.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            else if ((Alien10.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien10))
            {
                Alien10.Visibility = Visibility.Hidden;

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);

            }
            

            else if (SpaceCanvas.ActualHeight-Canvas.GetTop(bullet)<=0)
            {

                Canvas.SetTop(bullet, 408);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 20);
            }
            
            
            

           
        }


        // method for movement of spaceship
        private void spaceShipMove(string direction)
        {

            switch(direction)
            {
                case "Left":

                    SpaceshipXPos += -ship.velocityX;
                    Canvas.SetLeft(SpaceShip, SpaceshipXPos);
                    if(isShot == false)
                    {

                        Canvas.SetTop(bullet, 408);
                        Canvas.SetLeft(bullet, SpaceshipXPos + 20); break;

                    }
                    else
                    {
                        break;
                    }
                


                case "Right": SpaceshipXPos += ship.velocityX;
                    Canvas.SetLeft(SpaceShip, SpaceshipXPos);

                    if (isShot == false)
                    {
                        Canvas.SetLeft(bullet, SpaceshipXPos + 20); break;

                    }
                    else
                    {
                        break;
                    }
                    default: break;


            }
            
           

        }
    }
}
