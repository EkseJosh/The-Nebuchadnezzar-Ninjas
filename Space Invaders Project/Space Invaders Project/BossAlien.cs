using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Project
{
    public class BossAlien
    {
        public int lives { get; set; }
        public double velocityX { get; set; }
       
       
        public BossAlien(double velX)
        {
            lives = 5;
           
            velocityX = velX;

        }

      
    }
}
