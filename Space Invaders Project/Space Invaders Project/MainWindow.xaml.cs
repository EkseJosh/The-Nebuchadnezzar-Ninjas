using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ThinkLib;
using System.IO;
using System.Text;

namespace Space_Invaders_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Turtle BulletTurtle;
        Turtle BulletTurtle2;
        int level;
        DispatcherTimer timer;
        DispatcherTimer bossTimer;
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
        Aliens alien11;
        Aliens alien12;
        Aliens alien13;
        Aliens alien14;
        Aliens alien15;
        Aliens alien16;
        Aliens alien17;
        Aliens alien18;
        Aliens alien19;
        Aliens alien20;
        Aliens alien21;
        Aliens alien22;
        Aliens alien23;
        Aliens alien24;
        Aliens alien25;
        Aliens alien26;
        Aliens alien27;
        Aliens alien28;
        Aliens alien29;
        Aliens alien30;

        BossAlien boss1;
        BossAlien boss2;
        BossAlien boss3;
        SpaceShip ship;
        bool isShot = false;

        double SpaceshipXPos = 563; // left of spaceship relative to canvas (starting).
        double SpaceShipYPos = 513; // top of spaceship image relative to canvas...Must Not be changed.
        


        
    
        int score = 0;
        BitmapImage[] AlienPics;
        
        



        public MainWindow()
        {
            InitializeComponent();

            level = 1;
            

            BulletTurtle = new Turtle(SpaceCanvas);
            BulletTurtle2 = new Turtle(SpaceCanvas);
            BulletTurtle.Heading = 90;
            BulletTurtle2.Heading = 90;

            BulletTurtle.WarpTo(430,280);
           
            BulletTurtle2.WarpTo(724,280);

            BulletTurtle.Visible = false;
            BulletTurtle2.Visible = false;


            Canvas.SetLeft(SpaceShip, SpaceshipXPos);
            Canvas.SetTop(SpaceShip, SpaceShipYPos);




            // update screen Timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.IsEnabled = true;
            timer.Tick += Timer_Tick;

            // boss timer

            bossTimer = new DispatcherTimer();
            bossTimer.Interval = TimeSpan.FromMilliseconds(10);
            bossTimer.IsEnabled = false;
            bossTimer.Tick += BossTimer_Tick;

            // initialization of spaceship object 
            ship = new SpaceShip();
            ship.velocityX = 10;

            // initialisation of alien objects
            alien1 = new Aliens(1,2);
            alien2 = new Aliens(2,1);
            alien3 = new Aliens(3,2);
            alien4 = new Aliens(2,3);
            alien5 = new Aliens(3,1);
            alien6 = new Aliens(4,1);
            alien7 = new Aliens(1,4);
            alien8 = new Aliens(4,3);
            alien9 = new Aliens(3,4);
            alien10 = new Aliens(4,2);
            alien11 = new Aliens(2,4);
            alien12= new Aliens(1,1);
            alien13 = new Aliens(2,2);
            alien14 = new Aliens(3,3);
            alien15 = new Aliens(4,4);
            alien16 = new Aliens(1,3);
            alien17 = new Aliens(2,1);
            alien18 = new Aliens(3,2);
            alien19 = new Aliens(1,4);
            alien20 = new Aliens(4,2);
            alien21 = new Aliens(4,3);
            alien22 = new Aliens(3,1);
            alien23 = new Aliens(3,2);
            alien24 = new Aliens(5,2);
            alien25 = new Aliens(5,1);
            alien26 = new Aliens(3,5);
            alien27 = new Aliens(4,1);
            alien28 = new Aliens(1,3);
            alien29 = new Aliens(3,2);
            alien30 = new Aliens(4,1);


            // initialization of bosses

            boss1 = new BossAlien(3); ;
            

            boss2 = new BossAlien(5);
            boss2.lives = 7;

            boss3 = new BossAlien(8);
            boss3.lives = 9;

            // image sources for alien states
            string inThisProject = "pack://application:,,,/";
            AlienPics = new BitmapImage[] {
                        new BitmapImage(new Uri(inThisProject + "Gold Alien.png")),
                        new BitmapImage(new Uri(inThisProject + "Green Alien.png")) };




        }
        public void ShootBulletTurtle(Turtle bt, Turtle bt2)
        {

            bt.Heading = 90;
            bt2.Heading = 90;
            System.Threading.Thread.Sleep(10);
            bt.BrushDown = false;
            bt2.BrushDown = false;
            bt2.Forward(4);
            bt.Forward(4);

            if (CheckHitSpaceShip(BulletTurtle, BulletTurtle2) == true || (bt.Position.Y >= 609 && bt2.Position.Y >= 609 ))
            {
               
                bt.Goto(Canvas.GetLeft(BossLevel_1)+30,280);
                bt2.Goto(Canvas.GetLeft(BossLevel_1)+250,280);
            }
        }


        public bool CheckHitSpaceShip(Turtle bt, Turtle bt2)
        {
            Point minSpace = new Point(Canvas.GetLeft(SpaceShip), Canvas.GetTop(SpaceShip)+96);
            Point maxSpace = new Point(Canvas.GetLeft(SpaceShip)+76,Canvas.GetTop(SpaceShip));

            if (  (bt.Position.X >= minSpace.X && bt.Position.X <= maxSpace.X) && ((bt.Position.Y <= minSpace.Y) && (bt.Position.Y >= maxSpace.Y))   ||  ((bt2.Position.X >= minSpace.X && bt2.Position.X <= maxSpace.X) && ( (bt2.Position.Y <= minSpace.Y ) && (bt2.Position.Y >= maxSpace.Y)))   )
            {

                ship.lives--;
                return true;
            }
            else
            {
                return false;
            }



            
        }



    
        
       

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            spaceShipMove(ship);
            updateBullet();
            updateScore();
            AlienHitsSpaceship();
            updateLives();


            UpdateAlienMovement(Alien1,alien1);
            UpdateAlienMovement(Alien2,alien2);

            //UpdateAlienMovement(Alien3,alien3);
            //UpdateAlienMovement(Alien4,alien4);
            //UpdateAlienMovement(Alien5,alien5);
            //UpdateAlienMovement(Alien6,alien6);
            //UpdateAlienMovement(Alien7,alien7);
            //UpdateAlienMovement(Alien8,alien8);
            //UpdateAlienMovement(Alien9,alien9);
            //UpdateAlienMovement(Alien10,alien10);
            if(level == 3)
            {
                //UpdateAlienMovement(Alien11,alien11);
                //UpdateAlienMovement(Alien12,alien12);
                //UpdateAlienMovement(Alien13,alien13);
                //UpdateAlienMovement(Alien14,alien14);
                //UpdateAlienMovement(Alien15,alien15);
                //UpdateAlienMovement(Alien16,alien16);
                //UpdateAlienMovement(Alien17,alien17);
                //UpdateAlienMovement(Alien18,alien18);
                //UpdateAlienMovement(Alien19,alien19);
                //UpdateAlienMovement(Alien20,alien20);

            }
            if(level==5)
            {
                //UpdateAlienMovement(Alien21,alien21);
                //UpdateAlienMovement(Alien22,alien22);
                //UpdateAlienMovement(Alien23,alien23);
                //UpdateAlienMovement(Alien24,alien24);
                //UpdateAlienMovement(Alien25,alien25);
                //UpdateAlienMovement(Alien26,alien26);
                //UpdateAlienMovement(Alien27,alien27);
                //UpdateAlienMovement(Alien28,alien28);
                //UpdateAlienMovement(Alien29,alien29);
                //UpdateAlienMovement(Alien30,alien30);

            }

            
           
           
           
        }

        private void updateLives()
        {
            

            if (ship.lives == 2)
            {
                SpaceLife3.Visibility = Visibility.Hidden;
            }
           if(ship.lives == 1)
            {
                SpaceLife2.Visibility = Visibility.Hidden;
            }
           if(ship.lives ==0)
            {

                SpaceLife1.Visibility = Visibility.Hidden;
                if(level == 2)
                {
                    BossLevel_1.Visibility = Visibility.Hidden;
                }
                resetPositions();
                timer.IsEnabled = false;
                bossTimer.IsEnabled = false;

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
              
                updateLevel();
                txtStageNum.Text = $" STAGE {level}";
                
                timer.IsEnabled = true;
               





            }
            if( score == 150 && level ==2)
            {


                level++;
                timer.IsEnabled = false;
                
                updateLevel();
                txtStageNum.Text = $" STAGE {level}";

                timer.IsEnabled = true;
            }
        }

        public void BozzaMovement(Image boss,BossAlien b)
        {
            double nextY, nextX = 0;


            nextY = Canvas.GetTop(boss);
            nextX = Canvas.GetLeft(boss) + b.velocityX;

            if ((nextX <= 0 && b.velocityX < 0) || ((nextX >= SpaceCanvas.ActualWidth - boss.ActualWidth) && b.velocityX > 0))

            {
                b.velocityX = -(b.velocityX);

            }
            //if ((nextY <= 0 && b.velocityY < 0) || ((nextY >= SpaceCanvas.ActualHeight - boss.ActualHeight) && velocityY > 0))

            //{
            //    velocityY = -(velocityY);


            //}

            Canvas.SetLeft(boss, nextX);
            


        }

        public void UpdateAlienMovement(Image alien, Aliens a)
        {


            double nextY, nextX = 0;

            nextY = Canvas.GetTop(alien) + a.velocityY;
            nextX = Canvas.GetLeft(alien) + a.velocityX;

            if ((nextX <= 0 && a.velocityX < 0) || ((nextX >= SpaceCanvas.ActualWidth - alien.ActualWidth) && a.velocityX > 0))

            {
               a.velocityX = -(a.velocityX);

            }
            if ((nextY <= 0 && a.velocityY < 0) || ((nextY >= SpaceCanvas.ActualHeight - alien.ActualHeight) && a.velocityY > 0))

            {
                a.velocityY = -(a.velocityY);


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

        public void updateLevel()
        {
            if(level ==2)
            {
                BringBoss(BossLevel_1);
                BulletTurtle.Visible = true;
                BulletTurtle2.Visible = true;

            }

            if(level == 3)
            {
                BulletTurtle.Visible = false;
                BulletTurtle2.Visible = false;
                resetPositions();
                alien1.lives = 2;
                alien2.lives = 2;
                alien3.lives = 2;
                alien4.lives = 2;
                alien5.lives = 2;
                alien6.lives = 2;
                alien7.lives = 2;
                alien8.lives = 2;
                alien9.lives = 2;
                alien10.lives = 2;

                Alien11.Visibility = Visibility.Visible;
                Alien12.Visibility = Visibility.Visible;
                Alien13.Visibility = Visibility.Visible;
                Alien14.Visibility = Visibility.Visible;
                Alien15.Visibility = Visibility.Visible;
                Alien16.Visibility = Visibility.Visible;
                Alien17.Visibility = Visibility.Visible;
                Alien18.Visibility = Visibility.Visible;
                Alien19.Visibility = Visibility.Visible;
                Alien20.Visibility = Visibility.Visible;





            }
            else if(level == 5)
            {
                alien1.lives = 2;
                alien2.lives = 2;
                alien3.lives = 2;
                alien4.lives = 2;
                alien5.lives = 2;
                alien6.lives = 2;
                alien7.lives = 2;
                alien8.lives = 2;
                alien9.lives = 2;
                alien10.lives = 2;
                alien11.lives = 2;
                alien12.lives = 2;
                alien13.lives = 2;
                alien14.lives = 2;
                alien15.lives = 2;
                alien16.lives = 2;
                alien17.lives = 2;
                alien18.lives = 2;
                alien19.lives = 2;
                alien20.lives = 2;




                resetPositions();
                Alien21.Visibility = Visibility.Visible;
                Alien22.Visibility = Visibility.Visible;
                Alien23.Visibility = Visibility.Visible;
                Alien24.Visibility = Visibility.Visible;
                Alien25.Visibility = Visibility.Visible;
                Alien26.Visibility = Visibility.Visible;
                Alien27.Visibility = Visibility.Visible;
                Alien28.Visibility = Visibility.Visible;
                Alien29.Visibility = Visibility.Visible;
                Alien30.Visibility = Visibility.Visible;
            }
        }

        private void BringBoss(Image Boss)
        {
            timer.IsEnabled = false;
            Alien1.Visibility = Visibility.Hidden;
            Alien2.Visibility = Visibility.Hidden;
            Alien3.Visibility = Visibility.Hidden;
            Alien4.Visibility = Visibility.Hidden;
            Alien5.Visibility = Visibility.Hidden;
            Alien6.Visibility = Visibility.Hidden;
            Alien7.Visibility = Visibility.Hidden;
            Alien8.Visibility = Visibility.Hidden;
            Alien9.Visibility = Visibility.Hidden;
            Alien10.Visibility = Visibility.Hidden;
            Alien11.Visibility = Visibility.Hidden;
            Alien12.Visibility = Visibility.Hidden;
            Alien13.Visibility = Visibility.Hidden;
            Alien14.Visibility = Visibility.Hidden;
            Alien15.Visibility = Visibility.Hidden;
            Alien16.Visibility = Visibility.Hidden;
            Alien17.Visibility = Visibility.Hidden;
            Alien18.Visibility = Visibility.Hidden;
            Alien19.Visibility = Visibility.Hidden;
            Alien20.Visibility = Visibility.Hidden;
            Alien21.Visibility = Visibility.Hidden;
            Alien22.Visibility = Visibility.Hidden;
            Alien23.Visibility = Visibility.Hidden;
            Alien24.Visibility = Visibility.Hidden;
            Alien25.Visibility = Visibility.Hidden;
            Alien26.Visibility = Visibility.Hidden;
            Alien27.Visibility = Visibility.Hidden;
            Alien28.Visibility = Visibility.Hidden;
            Alien29.Visibility = Visibility.Hidden;
            Alien30.Visibility = Visibility.Hidden;
            Boss.Visibility = Visibility.Visible;

            bossTimer.IsEnabled = true;
        
            
        }

        private void BossTimer_Tick(object sender, EventArgs e)
        {
            

            if (level == 2)
            {
               
                BossLevel_1.Visibility = Visibility.Visible;
                BozzaMovement(BossLevel_1,boss1);
                ShootBulletTurtle(BulletTurtle, BulletTurtle2);
                CheckHitSpaceShip(BulletTurtle, BulletTurtle2);
                spaceShipMove(ship);
                updateBullet();
                updateScore();
                updateLives();

            }
            if( level == 4)
            {
               
                BozzaMovement(BossLevel_1,boss2);
                ShootBulletTurtle(BulletTurtle, BulletTurtle2);
                CheckHitSpaceShip(BulletTurtle, BulletTurtle2);
                spaceShipMove(ship);
                updateBullet();
                updateScore();
                updateLives();
            }
            if(level == 6)
            {
               
               
                BozzaMovement(BossLevel_1, boss3);
                ShootBulletTurtle(BulletTurtle, BulletTurtle2);
                CheckHitSpaceShip(BulletTurtle, BulletTurtle2);
                spaceShipMove(ship);
                updateBullet();
                updateScore();
                updateLives();

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
                            score += 10;

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
                        score += 10;

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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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
                        score += 10;
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
                            score += 10;
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

                else if ((Alien11.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien11))
                {
                    if (alien11.state == alienState.Normal && alien11.lives > 0)
                    {

                        Alien11.Source = AlienPics[1];
                        alien11.state = alienState.Weakened;
                        alien11.lives--;

                    }

                    else if (alien11.state == alienState.Weakened && alien11.lives > 0)
                    {
                        alien11.lives--;
                        if (alien11.lives == 0)
                        {
                            Alien11.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien11.lives--;
                        }
                    }
                    else
                    {
                        Alien11.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien12.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien12))
                {
                    if (alien12.state == alienState.Normal && alien12.lives > 0)
                    {

                        Alien12.Source = AlienPics[1];
                        alien12.state = alienState.Weakened;
                        alien12.lives--;

                    }

                    else if (alien12.state == alienState.Weakened && alien12.lives > 0)
                    {
                        alien12.lives--;
                        if (alien12.lives == 0)
                        {
                            Alien12.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien12.lives--;
                        }
                    }
                    else
                    {
                        Alien12.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien13.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien13))
                {
                    if (alien13.state == alienState.Normal && alien13.lives > 0)
                    {

                        Alien13.Source = AlienPics[1];
                        alien13.state = alienState.Weakened;
                        alien13.lives--;

                    }

                    else if (alien13.state == alienState.Weakened && alien13.lives > 0)
                    {
                        alien13.lives--;
                        if (alien13.lives == 0)
                        {
                            Alien13.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien13.lives--;
                        }
                    }
                    else
                    {
                        Alien13.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien14.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien14))
                {
                    if (alien14.state == alienState.Normal && alien14.lives > 0)
                    {

                        Alien14.Source = AlienPics[1];
                        alien14.state = alienState.Weakened;
                        alien14.lives--;

                    }

                    else if (alien14.state == alienState.Weakened && alien14.lives > 0)
                    {
                        alien14.lives--;
                        if (alien14.lives == 0)
                        {
                            Alien14.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien14.lives--;
                        }
                    }
                    else
                    {
                        Alien14.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien15.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien15))
                {
                    if (alien15.state == alienState.Normal && alien15.lives > 0)
                    {

                        Alien15.Source = AlienPics[1];
                        alien15.state = alienState.Weakened;
                        alien15.lives--;

                    }

                    else if (alien15.state == alienState.Weakened && alien15.lives > 0)
                    {
                        alien15.lives--;
                        if (alien15.lives == 0)
                        {
                            Alien15.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien15.lives--;
                        }
                    }
                    else
                    {
                        Alien15.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien16.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien16))
                {
                    if (alien16.state == alienState.Normal && alien16.lives > 0)
                    {

                        Alien16.Source = AlienPics[1];
                        alien16.state = alienState.Weakened;
                        alien16.lives--;

                    }

                    else if (alien16.state == alienState.Weakened && alien16.lives > 0)
                    {
                        alien16.lives--;
                        if (alien16.lives == 0)
                        {
                            Alien16.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien16.lives--;
                        }
                    }
                    else
                    {
                        Alien16.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien17.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien17))
                {
                    if (alien17.state == alienState.Normal && alien17.lives > 0)
                    {

                        Alien17.Source = AlienPics[1];
                        alien17.state = alienState.Weakened;
                        alien17.lives--;

                    }

                    else if (alien17.state == alienState.Weakened && alien17.lives > 0)
                    {
                        alien17.lives--;
                        if (alien17.lives == 0)
                        {
                            Alien17.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien17.lives--;
                        }
                    }
                    else
                    {
                        Alien17.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien18.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien18))
                {
                    if (alien18.state == alienState.Normal && alien18.lives > 0)
                    {

                        Alien18.Source = AlienPics[1];
                        alien18.state = alienState.Weakened;
                        alien18.lives--;

                    }

                    else if (alien18.state == alienState.Weakened && alien18.lives > 0)
                    {
                        alien18.lives--;
                        if (alien18.lives == 0)
                        {
                            Alien18.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien18.lives--;
                        }
                    }
                    else
                    {
                        Alien18.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien19.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien19))
                {
                    if (alien19.state == alienState.Normal && alien19.lives > 0)
                    {

                        Alien19.Source = AlienPics[1];
                        alien19.state = alienState.Weakened;
                        alien19.lives--;

                    }

                    else if (alien19.state == alienState.Weakened && alien19.lives > 0)
                    {
                        alien19.lives--;
                        if (alien19.lives == 0)
                        {
                            Alien19.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien19.lives--;
                        }
                    }
                    else
                    {
                        Alien19.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien20.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien20))
                {
                    if (alien20.state == alienState.Normal && alien20.lives > 0)
                    {

                        Alien20.Source = AlienPics[1];
                        alien20.state = alienState.Weakened;
                        alien20.lives--;

                    }

                    else if (alien20.state == alienState.Weakened && alien20.lives > 0)
                    {
                        alien20.lives--;
                        if (alien10.lives == 0)
                        {
                            Alien20.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien20.lives--;
                        }
                    }
                    else
                    {
                        Alien20.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien21.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien21))
                {
                    if (alien21.state == alienState.Normal && alien21.lives > 0)
                    {

                        Alien21.Source = AlienPics[1];
                        alien21.state = alienState.Weakened;
                        alien21.lives--;

                    }

                    else if (alien21.state == alienState.Weakened && alien21.lives > 0)
                    {
                        alien21.lives--;
                        if (alien21.lives == 0)
                        {
                            Alien21.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien21.lives--;
                        }
                    }
                    else
                    {
                        Alien21.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien22.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien22))
                {
                    if (alien22.state == alienState.Normal && alien22.lives > 0)
                    {

                        Alien22.Source = AlienPics[1];
                        alien22.state = alienState.Weakened;
                        alien22.lives--;

                    }

                    else if (alien22.state == alienState.Weakened && alien22.lives > 0)
                    {
                        alien22.lives--;
                        if (alien22.lives == 0)
                        {
                            Alien22.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien22.lives--;
                        }
                    }
                    else
                    {
                        Alien22.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien23.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien23))
                {
                    if (alien23.state == alienState.Normal && alien23.lives > 0)
                    {

                        Alien23.Source = AlienPics[1];
                        alien23.state = alienState.Weakened;
                        alien23.lives--;

                    }

                    else if (alien23.state == alienState.Weakened && alien23.lives > 0)
                    {
                        alien23.lives--;
                        if (alien23.lives == 0)
                        {
                            Alien23.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien23.lives--;
                        }
                    }
                    else
                    {
                        Alien23.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien24.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien24))
                {
                    if (alien24.state == alienState.Normal && alien24.lives > 0)
                    {

                        Alien24.Source = AlienPics[1];
                        alien24.state = alienState.Weakened;
                        alien24.lives--;

                    }

                    else if (alien24.state == alienState.Weakened && alien24.lives > 0)
                    {
                        alien24.lives--;
                        if (alien24.lives == 0)
                        {
                            Alien24.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien24.lives--;
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

                else if ((Alien25.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien25))
                {
                    if (alien25.state == alienState.Normal && alien25.lives > 0)
                    {

                        Alien25.Source = AlienPics[1];
                        alien25.state = alienState.Weakened;
                        alien25.lives--;

                    }

                    else if (alien25.state == alienState.Weakened && alien25.lives > 0)
                    {
                        alien25.lives--;
                        if (alien25.lives == 0)
                        {
                            Alien25.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien25.lives--;
                        }
                    }
                    else
                    {
                        Alien25.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien26.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien26))
                {
                    if (alien26.state == alienState.Normal && alien26.lives > 0)
                    {

                        Alien26.Source = AlienPics[1];
                        alien26.state = alienState.Weakened;
                        alien26.lives--;

                    }

                    else if (alien26.state == alienState.Weakened && alien26.lives > 0)
                    {
                        alien26.lives--;
                        if (alien26.lives == 0)
                        {
                            Alien26.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien26.lives--;
                        }
                    }
                    else
                    {
                        Alien26.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien27.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien27))
                {
                    if (alien27.state == alienState.Normal && alien27.lives > 0)
                    {

                        Alien27.Source = AlienPics[1];
                        alien27.state = alienState.Weakened;
                        alien27.lives--;

                    }

                    else if (alien27.state == alienState.Weakened && alien27.lives > 0)
                    {
                        alien27.lives--;
                        if (alien27.lives == 0)
                        {
                            Alien27.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien27.lives--;
                        }
                    }
                    else
                    {
                        Alien27.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien28.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien28))
                {
                    if (alien28.state == alienState.Normal && alien28.lives > 0)
                    {

                        Alien28.Source = AlienPics[1];
                        alien28.state = alienState.Weakened;
                        alien28.lives--;

                    }

                    else if (alien28.state == alienState.Weakened && alien28.lives > 0)
                    {
                        alien28.lives--;
                        if (alien28.lives == 0)
                        {
                            Alien28.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien28.lives--;
                        }
                    }
                    else
                    {
                        Alien28.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien29.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien29))
                {
                    if (alien29.state == alienState.Normal && alien29.lives > 0)
                    {

                        Alien29.Source = AlienPics[1];
                        alien29.state = alienState.Weakened;
                        alien29.lives--;

                    }

                    else if (alien29.state == alienState.Weakened && alien29.lives > 0)
                    {
                        alien29.lives--;
                        if (alien29.lives == 0)
                        {
                            Alien29.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien29.lives--;
                        }
                    }
                    else
                    {
                        Alien29.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }



                }

                else if ((Alien30.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(Alien30))
                {
                    if (alien30.state == alienState.Normal && alien30.lives > 0)
                    {

                        Alien30.Source = AlienPics[1];
                        alien30.state = alienState.Weakened;
                        alien30.lives--;

                    }

                    else if (alien30.state == alienState.Weakened && alien30.lives > 0)
                    {
                        alien30.lives--;
                        if (alien30.lives == 0)
                        {
                            Alien30.Visibility = Visibility.Hidden;

                            Canvas.SetTop(bullet, 459);
                            Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                            score += 10;
                        }
                        else
                        {
                            alien30.lives--;
                        }
                    }
                    else
                    {
                        Alien30.Visibility = Visibility.Hidden;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);
                        score++;
                    }

                }
                else if ((BossLevel_1.Visibility != Visibility.Hidden) && bulletCollidesWithAlien(BossLevel_1))
                {
                    if (boss1.lives > 0)
                    {

                        boss1.lives--;
                        double temp = boss1.velocityX;
                       Random rnd = new Random();
                        boss1.velocityX = temp + rnd.Next(1,3);
                        boss1.velocityX = temp;

                        Canvas.SetTop(bullet, 459);
                        Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);

                    }
                    if(boss1.lives == 0)
                    {
                        score += 50;
                        BossLevel_1.Visibility = Visibility.Hidden;
                        bossTimer.IsEnabled = false;
                        timer.IsEnabled = true;
                    }

                }



                else if (SpaceCanvas.ActualHeight - Canvas.GetTop(bullet) <= 0)
                {
                    Canvas.SetTop(bullet, 459);
                    Canvas.SetLeft(bullet, Canvas.GetLeft(SpaceShip) + 22);


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
        }     // Detection


        public bool alienCollidesWithSpaceShip(Image alien)
        {
            double alienX = Canvas.GetLeft(alien) + alien.ActualWidth / 2.0;
            double alienY = Canvas.GetTop(alien) + alien.ActualHeight;

            double pX0 = Canvas.GetLeft(SpaceShip);
            double pX1 = pX0 + SpaceShip.ActualHeight;
            double pY = Canvas.GetTop(SpaceShip);

            bool hits = alienX >= pX0 && alienX < pX1 && alienY >= pY;

            return hits;
        }  // Detection


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
                        laser.Visibility = Visibility.Hidden;
                        Canvas.SetLeft(laser, Canvas.GetLeft(SpaceShip) + 24);
                        break;
                    }
                    else
                    {
                        laser.Visibility = Visibility.Hidden;
                        break;
                    }

                case Movement.Right:
                    if (nextX < SpaceCanvas.ActualWidth - SpaceShip.ActualWidth)
                    {
                        Canvas.SetLeft(SpaceShip, nextX + ship.velocityX);
                        System.Threading.Thread.Sleep(2);
                        laser.Visibility = Visibility.Hidden;
                        Canvas.SetLeft(laser, Canvas.GetLeft(SpaceShip) + 24); break;
                    }
                    else
                    {
                        laser.Visibility = Visibility.Hidden;
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
            else if ((Alien11.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien11))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien12.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien12))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien13.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien13))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien14.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien14))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien15.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien15))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien16.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien16))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien17.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien17))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien18.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien18))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien19.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien19))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien20.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien20))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien21.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien21))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien22.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien22))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien23.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien23))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien24.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien24))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien25.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien25))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien26.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien26))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien27.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien27))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien28.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien28))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien29.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien29))
            {

                ship.lives--;
                resetPositions();



            }
            else if ((Alien30.Visibility != Visibility.Hidden) && alienCollidesWithSpaceShip(Alien30))
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
            laser.Visibility = Visibility.Hidden;
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
            Canvas.SetLeft(Alien4, 525);
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

            if(level == 3)
            {

                Canvas.SetTop(Alien11, 102);
                Canvas.SetLeft(Alien11, 10);
                alien11.state = alienState.Normal;
                Alien11.Source = AlienPics[0];
                Alien11.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien12, 102);
                Canvas.SetLeft(Alien12, 109);
                alien12.state = alienState.Normal;
                Alien12.Source = AlienPics[0];
                Alien12.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien13, 102);
                Canvas.SetLeft(Alien13, 209);
                alien13.state = alienState.Normal;
                Alien13.Source = AlienPics[0];
                Alien13.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien14, 102);
                Canvas.SetLeft(Alien14, 314);
                alien14.state = alienState.Normal;
                Alien14.Source = AlienPics[0];
                Alien14.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien15, 102);
                Canvas.SetLeft(Alien15, 425);
                alien15.state = alienState.Normal;
                Alien15.Source = AlienPics[0];
                Alien15.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien16, 102);
                Canvas.SetLeft(Alien16, 525);
                alien16.state = alienState.Normal;
                Alien16.Source = AlienPics[0];
                Alien16.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien17, 102);
                Canvas.SetLeft(Alien17, 625);
                alien17.state = alienState.Normal;
                Alien17.Source = AlienPics[0];
                Alien17.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien18, 102);
                Canvas.SetLeft(Alien18, 725);
                alien18.state = alienState.Normal;
                Alien18.Source = AlienPics[0];
                Alien18.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien19, 102);
                Canvas.SetLeft(Alien19, 825);
                alien19.state = alienState.Normal;
                Alien19.Source = AlienPics[0];
                Alien19.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien20, 102);
                Canvas.SetLeft(Alien20, 925);
                alien20.state = alienState.Normal;
                Alien20.Source = AlienPics[0];
                Alien20.Visibility = Visibility.Visible;
            }
            if(level == 5)
            {
                Canvas.SetTop(Alien21, 193);
                Canvas.SetLeft(Alien21, 10);
                alien21.state = alienState.Normal;
                Alien21.Source = AlienPics[0];
                Alien21.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien22, 193);
                Canvas.SetLeft(Alien22, 109);
                alien22.state = alienState.Normal;
                Alien22.Source = AlienPics[0];
                Alien22.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien23, 193);
                Canvas.SetLeft(Alien23, 209);
                alien23.state = alienState.Normal;
                Alien23.Source = AlienPics[0];
                Alien23.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien24, 193);
                Canvas.SetLeft(Alien24, 314);
                alien24.state = alienState.Normal;
                Alien24.Source = AlienPics[0];
                Alien24.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien25, 193);
                Canvas.SetLeft(Alien25, 425);
                alien25.state = alienState.Normal;
                Alien25.Source = AlienPics[0];
                Alien25.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien26, 193);
                Canvas.SetLeft(Alien26, 525);
                alien26.state = alienState.Normal;
                Alien26.Source = AlienPics[0];
                Alien26.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien27, 193);
                Canvas.SetLeft(Alien27, 625);
                alien27.state = alienState.Normal;
                Alien27.Source = AlienPics[0];
                Alien27.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien28, 193);
                Canvas.SetLeft(Alien28, 725);
                alien28.state = alienState.Normal;
                Alien28.Source = AlienPics[0];
                Alien28.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien29, 193);
                Canvas.SetLeft(Alien29, 825);
                alien29.state = alienState.Normal;
                Alien29.Source = AlienPics[0];
                Alien29.Visibility = Visibility.Visible;

                Canvas.SetTop(Alien30, 193);
                Canvas.SetLeft(Alien30, 925);
                alien30.state = alienState.Normal;
                Alien30.Source = AlienPics[0];
                Alien30.Visibility = Visibility.Visible;

            }

           
        }
    }
}
