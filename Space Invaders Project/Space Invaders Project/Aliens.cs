using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Project
{
    public enum alienState { Normal,Weakened}
    public class Aliens
    {

        public int lives { get; set; }
        public double velocityX { get; set; }
        public double velocityY { get; set; }
       
        public alienState state {get;set;}
       

        public Aliens(double velX,double velY)
        {
            lives = 2;
            
            state = alienState.Normal;
            velocityX = velX;
            velocityY = velY;

        }

        

    }
}
