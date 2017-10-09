using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Project
{
    public enum boosters {shield,bulletSpeed,bulletNum,movementSpeed }
    public enum Movement { Left,Right,Stopped}
    class SpaceShip
    {
    public int lives { get; set; }
        public double velocityX { get; set; }
        public boosters boost { get; set; }
        public List<boosters> powerUps { get; set; } // keeps track of how many boosters are active
       public  Movement state;

        public SpaceShip()
        {
            lives = 3;
            powerUps = new List<boosters>();
            state = Movement.Stopped;
        }




    }
}
