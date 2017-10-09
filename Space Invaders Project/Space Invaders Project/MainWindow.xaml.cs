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
        int level;
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

        int score = 0;
        BitmapImage[] AlienPics;
        // This is tells C# to find the images "in this application" ...




        public MainWindow()
        {
            InitializeComponent();
           
            level = 1;

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
            AlienHitsSpaceship();
            updateLives();

        }

        private void updateLives()
        {
           if(ship.lives == 2)
            {
                SpaceLife3.Visibility = Visibility.Hidden;
            }
           if(ship.lives == 1)
            {
                SpaceLife2.Visibility = Visibility.Hidden;
            }
           if(ship.lives ==0)
            {

                resetPositions();
                timer.IsEnabled = false;

            }
        }

        private void updateScore()
        {

            txtScore.Text = $"SCORE: {score}";
            if(score == 100 && level ==1)
            {
                // updates level

                level++;
                timer.IsEnabled = false;
                resetPositions();
                
                txtStageNum.Text = $" STAGE {level}";
                
                timer.IsEnabled = true;





            }
        }

       

        public void UpdateAlienMovement(Image alien)
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
            if (isShot == false)
            {
                Canvas.SetTop(laser, 125);
                Canvas.SetLeft(laser, Canvas.GetLeft(SpaceShip) + 24);
                Canvas.SetTop(bullet, 459);
                Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);

            }
            else
            {
                laser.Visibility = Visibility.Visible;

                double nextY = Canvas.GetTop(bullet);
                Canvas.SetTop(bullet, nextY + 2);


                if ((Alien1.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien1))
                {
                    if (alien1.state == alienState.Normal && alien1.lives > 0)
                    {

                        Alien1.Source = AlienPics[1];
                        alien1.state = alienState.Weakened;
                        alien1.lives--;

                    }

                    else if (alien1.state == alienState.Weakened && alien1.lives > 0)
                    {
                        alien1.lives--;
                        if (alien1.lives == 0)
                        {
                            Alien1.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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
                        score+=10;
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
                            score+=10;
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


        public bool alienCollidesWithSpaceShip(Image alien)
        {
            double alienX = Canvas.GetLeft(alien) + alien.ActualWidth / 2.0;
            double alienY = Canvas.GetTop(alien) + alien.ActualHeight;

            double pX0 = Canvas.GetLeft(SpaceShip);
            double pX1 = pX0 + SpaceShip.ActualHeight;
            double pY = Canvas.GetTop(SpaceShip);

            bool hits = alienX >= pX0 && alienX < pX1 && alienY >= pY;

            return hits;
        }


        // method for movement of spaceship
        private void spaceShipMove(SpaceShip s)
        {
            double nextX = Canvas.GetLeft(SpaceShip);
            switch (s.state)
            {
                case Movement.Left:
                    if (nextX > 0)
                    {
                        Canvas.SetLeft(SpaceShip, nextX - ship.velocityX);
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


        public void AlienHitsSpaceship()
        {
            if ((Alien1.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien1))
            {
                
                ship.lives--;
                resetPositions();
                
                
              

            }
            else if((Alien2.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien2))
            {
               
                ship.lives--;

                resetPositions();
                
               
                
            }
            else if ((Alien3.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien3))
            {
               
                ship.lives--;
                resetPositions();
                
               
                
            }
            else if ((Alien4.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien4))
            {
                
                ship.lives--;
                resetPositions();
                
                
               
            }
            else if ((Alien5.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien5))
            {
               
                ship.lives--;
                resetPositions();
                
              
                
            }
            else if ((Alien6.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien6))
            {
                
                ship.lives--;
                resetPositions();
                

                System.Threading.Thread.Sleep(5000);
                
            }
            else if ((Alien7.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien7))
            {
                
                ship.lives--;
                resetPositions();
                
                
               
            }
            else if ((Alien8.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien8))
            {
                
                ship.lives--;
                resetPositions();
                
               
                
            }
            else if ((Alien9.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien9))
            {
                
                ship.lives--;
                resetPositions();
               
               
                
            }
            else if ((Alien10.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien10))
            {
                
                ship.lives--;
                resetPositions();
                
                
                
            }
        }

        private void resetPositions()
        {
            // resets spaceship positions
            Canvas.SetLeft(SpaceShip, SpaceshipXPos);
            Canvas.SetTop(SpaceShip, SpaceShipYPos);

            // reset bullet and laser image
            Canvas.SetTop(laser, 125);
            Canvas.SetLeft(laser, Canvas.GetLeft(SpaceShip) + 24);
            Canvas.SetTop(bullet, 459);
            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);

            // reset alien positions
            Canvas.SetTop(Alien1, 10);
            Canvas.SetLeft(Alien1, 425);
            alien1.state = alienState.Normal;
            Alien1.Source = AlienPics[0];
            Alien1.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien2, 10);
            Canvas.SetLeft(Alien2, 314);
            alien2.state = alienState.Normal;
            Alien2.Source = AlienPics[0];
            Alien2.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien3, 10);
            Canvas.SetLeft(Alien3, 209);
            alien3.state = alienState.Normal;
            Alien3.Source = AlienPics[0];
            Alien3.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien4, 10);
            Canvas.SetLeft(Alien8, 525);
            alien4.state = alienState.Normal;
            Alien4.Source = AlienPics[0];
            Alien4.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien5, 10);
            Canvas.SetLeft(Alien5, 625);
            alien5.state = alienState.Normal;
            Alien5.Source = AlienPics[0];
            Alien5.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien6, 10);
            Canvas.SetLeft(Alien6, 725);
            alien6.state = alienState.Normal;
            Alien6.Source = AlienPics[0];
            Alien6.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien7, 10);
            Canvas.SetLeft(Alien7, 109);
            alien7.state = alienState.Normal;
            Alien7.Source = AlienPics[0];
            Alien7.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien8, 10);
            Canvas.SetLeft(Alien8, 10);
            alien8.state = alienState.Normal;
            Alien8.Source = AlienPics[0];
            Alien8.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien9, 10);
            Canvas.SetLeft(Alien9, 825);
            alien9.state = alienState.Normal;
            Alien9.Source = AlienPics[0];
            Alien9.Visibility = Visibility.Visible;

            Canvas.SetTop(Alien10, 10);
            Canvas.SetLeft(Alien10, 925);
            alien10.state = alienState.Normal;
            Alien10.Source = AlienPics[0];
            Alien10.Visibility = Visibility.Visible;

           
        }
    }
}
