using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Space_Invaders_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DispatcherTimer timer;

        Aliens alien1;
        Aliens alien2;
        Aliens alien3;
        Aliens alien4;
        Aliens alien5;
        Aliens alien6;
        Aliens alien7;
        Aliens alien8;
        Aliens alien9;
        Aliens alien10;

        SpaceShip ship;
        bool isShot = false;
        
        double SpaceshipXPos = 563; // left of spaceship relative to canvas (starting).
        double SpaceShipYPos = 510; // top of spaceship image relative to canvas...Must Not be changed.


        int velocityY = 3; // alien velocity variables
        int velocityX = 3;
        public Random rnd;

        int score = 0;
        BitmapImage[] AlienPics;
        // This is tells C# to find the images "in this application" ...
        



        public MainWindow()
        {
            InitializeComponent();

            
            Canvas.SetLeft(SpaceShip, SpaceshipXPos);
            Canvas.SetTop(SpaceShip, SpaceShipYPos);




            // update screen Timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;

            

            // initialization of spaceship object 
            ship = new SpaceShip();
            ship.velocityX = 10;

            // initialisation of alien objects
            alien1 = new Aliens();
            alien2 = new Aliens();
            alien3 = new Aliens();
            alien4 = new Aliens();
            alien5 = new Aliens();
            alien6 = new Aliens();
            alien7 = new Aliens();
            alien8 = new Aliens();
            alien9 = new Aliens();
            alien10 = new Aliens();

            // image sources for alien states
            string inThisProject = "pack://application:,,,/";
            AlienPics = new BitmapImage[] {
                        new BitmapImage(new Uri(inThisProject + "Gold Alien.png")),
                        new BitmapImage(new Uri(inThisProject + "Green Alien.png")) };




        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateAlienMovement(Alien1);
            UpdateAlienMovement(Alien2);
            //UpdateAlienMovement(Alien3);
            //UpdateAlienMovement(Alien4);
            //UpdateAlienMovement(Alien5);
            //UpdateAlienMovement(Alien6);
            //UpdateAlienMovement(Alien7);
            //UpdateAlienMovement(Alien8);
            //UpdateAlienMovement(Alien9);
            //UpdateAlienMovement(Alien10);
            spaceShipMove(ship);
            updateBullet();
            updateScore();
            BozzaMovement(BossAlien);
            
        }

       

        private void updateScore()
        {
            
            txtScore.Text = $"SCORE: {score}";
        }

        public void UpdateAlienMovement( Image alien)
        {
            
          
            double nextY, nextX = 0;
            
             nextY = Canvas.GetTop(alien) + velocityY;
             nextX = Canvas.GetLeft(alien) + velocityX;

            if ((nextX <= 0 && velocityX < 0) || ((nextX >= SpaceCanvas.ActualWidth - alien.ActualWidth) && velocityX > 0))

            {
                velocityX = -(velocityX);

            }
            if ((nextY <= 0 && velocityY < 0) || ((nextY >= SpaceCanvas.ActualHeight - alien.ActualHeight) && velocityY > 0))

            {
                velocityY = -(velocityY);
               

            }

            Canvas.SetLeft(alien, nextX);
            Canvas.SetTop(alien, nextY);
            






        }
        public void BozzaMovement(Image alien)
        {
            double nextY, nextX = 0;
            rnd = new Random();

            nextY = Canvas.GetTop(alien) + velocityY;
            nextX = Canvas.GetLeft(alien) + velocityX*rnd.Next(1,3);

            if ((nextX <= 0 && velocityX < 0) || ((nextX >= SpaceCanvas.ActualWidth - alien.ActualWidth) && velocityX > 0))

            {
                velocityX = -(velocityX);

            }
            if ((nextY <= 0 && velocityY < 0) || ((nextY >= SpaceCanvas.ActualHeight - alien.ActualHeight) && velocityY > 0))

            {
                velocityY = -(velocityY);


            }

            Canvas.SetLeft(alien, nextX);
            Canvas.SetTop(alien, nextY);


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.Left: ship.state = Movement.Left; break;
                case Key.Right: ship.state = Movement.Right; break;
                case Key.Space: isShot = true; break;
                default: break;
            }
        }

        
                    

        

        private void updateBullet()
        {
            if(isShot == false)
            {
                Canvas.SetTop(laser, 78);
                Canvas.SetLeft(laser, Canvas.GetLeft(SpaceShip) + 25);
                Canvas.SetTop(bullet, 459);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
               
            }
            else 
            {
                laser.Visibility = Visibility.Visible;
               
                double nextY = Canvas.GetTop(bullet);
                Canvas.SetTop(bullet, nextY +2);
             

                if ((Alien1.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien1))
                {
                    if(alien1.state == alienState.Normal && alien1.lives >0)
                    {

                        Alien1.Source = AlienPics[1];
                        alien1.state = alienState.Weakened;
                        alien1.lives--;
                        
                    }

                    else if(alien1.state == alienState.Weakened && alien1.lives >0)
                    {
                        alien1.lives--;
                        if (alien1.lives == 0)
                        {
                            Alien1.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien1.lives--;
                        }
                    }
                    else
                    {
                        Alien1.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }
                        
                          
                    
                    
                    
                }
                else if ((Alien2.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien2))
                {

                    if (alien2.state == alienState.Normal && alien2.lives > 0)
                    {

                        Alien2.Source = AlienPics[1];
                        alien2.state = alienState.Weakened;
                        alien2.lives--;

                    }

                    else if (alien2.state == alienState.Weakened && alien2.lives > 0)
                    {
                        alien2.lives--;
                        if (alien2.lives == 0)
                        {
                            Alien2.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien2.lives--;
                        }
                    }
                    else
                    {
                        Alien2.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }


                }
                else if ((Alien3.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien3))
                {
                    if (alien3.state == alienState.Normal && alien3.lives > 0)
                    {

                        Alien3.Source = AlienPics[1];
                        alien3.state = alienState.Weakened;
                        alien3.lives--;

                    }

                    else if (alien3.state == alienState.Weakened && alien3.lives > 0)
                    {
                        alien3.lives--;
                        if (alien3.lives == 0)
                        {
                            Alien3.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien3.lives--;
                        }
                    }
                    else
                    {
                        Alien3.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }
                else if ((Alien4.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien4))
                {
                    if (alien4.state == alienState.Normal && alien4.lives > 0)
                    {

                        Alien4.Source = AlienPics[1];
                        alien4.state = alienState.Weakened;
                        alien4.lives--;

                    }

                    else if (alien4.state == alienState.Weakened && alien4.lives > 0)
                    {
                        alien4.lives--;
                        if (alien4.lives == 0)
                        {
                            Alien4.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien4.lives--;
                        }
                    }
                    else
                    {
                        Alien4.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }


                }
                else if ((Alien5.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien5))
                {
                    if (alien5.state == alienState.Normal && alien5.lives > 0)
                    {

                        Alien5.Source = AlienPics[1];
                        alien5.state = alienState.Weakened;
                        alien5.lives--;

                    }

                    else if (alien5.state == alienState.Weakened && alien5.lives > 0)
                    {
                        alien5.lives--;
                        if (alien5.lives == 0)
                        {
                            Alien5.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien5.lives--;
                        }
                    }
                    else
                    {
                        Alien5.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }
                else if ((Alien6.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien6))
                {
                    if (alien6.state == alienState.Normal && alien6.lives > 0)
                    {

                        Alien6.Source = AlienPics[1];
                        alien6.state = alienState.Weakened;
                        alien6.lives--;

                    }

                    else if (alien6.state == alienState.Weakened && alien6.lives > 0)
                    {
                        alien6.lives--;
                        if (alien6.lives == 0)
                        {
                            Alien6.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien6.lives--;
                        }
                    }
                    else
                    {
                        Alien6.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }
                else if ((Alien7.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien7))
                {
                    if (alien7.state == alienState.Normal && alien7.lives > 0)
                    {

                        Alien7.Source = AlienPics[1];
                        alien7.state = alienState.Weakened;
                        alien7.lives--;

                    }

                    else if (alien7.state == alienState.Weakened && alien7.lives > 0)
                    {
                        alien7.lives--;
                        if (alien7.lives == 0)
                        {
                            Alien7.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien7.lives--;
                        }
                    }
                    else
                    {
                        Alien7.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }
                else if ((Alien8.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien8))
                {
                    if (alien8.state == alienState.Normal && alien8.lives > 0)
                    {

                        Alien8.Source = AlienPics[1];
                        alien8.state = alienState.Weakened;
                        alien8.lives--;

                    }

                    else if (alien8.state == alienState.Weakened && alien8.lives > 0)
                    {
                        alien8.lives--;
                        if (alien8.lives == 0)
                        {
                            Alien8.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien8.lives--;
                        }
                    }
                    else
                    {
                        Alien8.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }
                else if ((Alien9.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien9))
                {
                    if (alien9.state == alienState.Normal && alien9.lives > 0)
                    {

                        Alien9.Source = AlienPics[1];
                        alien9.state = alienState.Weakened;
                        alien9.lives--;

                    }

                    else if (alien9.state == alienState.Weakened && alien9.lives > 0)
                    {
                        alien9.lives--;
                        if (alien9.lives == 0)
                        {
                            Alien9.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien9.lives--;
                        }
                    }
                    else
                    {
                        Alien9.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }
                else if ((Alien10.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien10))
                {
                    if (alien10.state == alienState.Normal && alien10.lives > 0)
                    {

                        Alien10.Source = AlienPics[1];
                        alien10.state = alienState.Weakened;
                        alien10.lives--;

                    }

                    else if (alien10.state == alienState.Weakened && alien10.lives > 0)
                    {
                        alien10.lives--;
                        if (alien10.lives == 0)
                        {
                            Alien10.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score++;
                        }
                        else
                        {
                            alien10.lives--;
                        }
                    }
                    else
                    {
                        Alien10.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }


                else if (SpaceCanvas.ActualHeight - Canvas.GetTop(bullet) <= 0)
                {

                    Canvas.SetTop(bullet, 459);
                    Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                    score++;


                }

            }
            
        }

        // detection of bullet with alien

        public bool bulletCollidesWithAlien(Image alien)
        {
            double bulletX = Canvas.GetLeft(bullet) + bullet.ActualWidth / 2.0;
            double bulletY = Canvas.GetTop(bullet) + bullet.ActualHeight;
            double leftalien = Canvas.GetLeft(alien);
            double alienX = leftalien + alien.ActualHeight;
            double ta = Canvas.GetTop(alien);
            bool hits = bulletX >= leftalien && bulletX < alienX && bulletY >= ta;
            
            isShot = false;
            return hits;
        }

        


        // method for movement of spaceship
        private void spaceShipMove(SpaceShip s)
        {
            double nextX = Canvas.GetLeft(SpaceShip);
            switch(s.state)
            {
                case Movement.Left:
                    if (nextX > 0)
                    {
                        Canvas.SetLeft(SpaceShip, nextX-ship.velocityX);
                        System.Threading.Thread.Sleep(2);
                        laser.Visibility = Visibility.Hidden; break;
                    }
                    else
                    {
                        break;
                    }

                case Movement.Right:
                    if (nextX < SpaceCanvas.ActualWidth - SpaceShip.ActualWidth)
                    {
                        Canvas.SetLeft(SpaceShip, nextX + ship.velocityX);
                        System.Threading.Thread.Sleep(2);
                        laser.Visibility = Visibility.Hidden; break;
                    }
                    else
                    {
                        break;
                    }

                case Movement.Stopped:
                    {
                        break;
                    }

                


            }
            
           

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            ship.state = Movement.Stopped;
        }

        
    }
}
