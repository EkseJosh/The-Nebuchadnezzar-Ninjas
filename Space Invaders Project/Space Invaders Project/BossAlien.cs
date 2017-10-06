using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Project
{
    class BossAlien
    {
        public int lives { get; set; }
        public double velocityX { get; set; }
        public double velocityY { get; set; }
        public boosters boost { get; set; }
        public List<boosters> powerUps { get; set; } // keeps track of how many boosters are active

        public BossAlien()
        {
            velocityY = 0;
            powerUps = new List<boosters>(); 

        }

        public void attack()
        {
            velocityX = 0;    //velocity before attack
            velocityY = 5; // velocity while attacking
            velocityY = 0; // velocity return to normal for normal movemnt
        }
    }
}
